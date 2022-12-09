using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Mouvement : MonoBehaviour
{
    private Animator anim;
    private Vector2 direction = new Vector2();
    private float vitesse = 10.0f;
    private Rigidbody2D body;
    private bool verif = false;
    private Dictionary<int, (HPT, int)> dicOPEN;
    private Dictionary<int, (HPT, int)> dicCLOSE;
    private List<Tile> tilepath, tilepathEnnemi;
    private List<(Vector2,string,Sol)> vecteurDeplacement;
    private GameObject vaisseau, vaisseauEnnemi;
    private Vaisseau Test, TestEnnemi;
    private int compteur = 2;
    private bool trouver = false;
    private bool enPAth = false;
    private int indexPath = 0;
    private bool vEnnemi;
    private MembreEquipage membre;
    private bool parentFinalTrouver = false;

    void Start()
    {

        anim = this.GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        membre = body.transform.gameObject.GetComponent<MembreEquipage>();
        membre.etat = MembreEquipage.EnumEquipages.ePassif;

        vEnnemi = body.transform.gameObject.GetComponent<MembreEquipage>().ennemi;
    }

    void Update()
    {

        if (deplacement())
        {
            anim.SetFloat("Horizontal", direction.x);
            anim.SetFloat("Vertical", direction.y);
            anim.SetFloat("Vitesse", direction.sqrMagnitude);

            body.velocity = direction * vitesse;

            if (direction.sqrMagnitude > 0.1f)
            {
                anim.SetFloat("LastH", direction.x);
                anim.SetFloat("LastV", direction.y);
            }
            direction.Normalize();
        }


        if (deplacementpathFinding() && trouver && enPAth)
        {
            // https://www.youtube.com/watch?v=alU04hvz6L4 // temps 22:25
            if (vecteurDeplacement != null && parentFinalTrouver)
            {
                Vector3 targetPosition = vecteurDeplacement[indexPath].Item1;
                if (Vector3.Distance(transform.position,targetPosition) > 1.2f)
                {
                    Vector3 moveDir = (targetPosition - transform.position);

                    //float distanceBefore = Vector3.Distance(transform.position, targetPosition.normalized);
                    anim.SetFloat("Horizontal", moveDir.x);
                    anim.SetFloat("Vertical", moveDir.y);
                    anim.SetFloat("Vitesse", moveDir.sqrMagnitude);
                    // pour ajuster le tile present
                    body.transform.SetParent(GameObject.Find(vecteurDeplacement[indexPath].Item2).transform);
                    membre.tuile = vecteurDeplacement[indexPath].Item3;

                    transform.position = transform.position + moveDir.normalized * vitesse * 6 * Time.deltaTime;
                    moveDir.Normalize();
                }

                else
                {
                    indexPath++;

                    if (indexPath + 1 >= vecteurDeplacement.Count)
                    {
                        StopMoving();
                        membre.etat = MembreEquipage.EnumEquipages.ePassif;
                        enPAth = false;
                    }
                }
            }
            
        }
    }

    private void StopMoving()
    {
        vecteurDeplacement = null;
        indexPath = 0;
        parentFinalTrouver = false;
    }

    private bool deplacementpathFinding()
    {
        return (membre.etat & (MembreEquipage.EnumEquipages.eDeplacementPathfindin | MembreEquipage.EnumEquipages.ePathFinding)) != 0;
    }

    private bool deplacement()
    {
        return (membre.etat & (MembreEquipage.EnumEquipages.eDeplacement | MembreEquipage.EnumEquipages.ePassif)) != 0;
    }


    void FixedUpdate()
    {

        if (membre.etat == MembreEquipage.EnumEquipages.ePassif && !verif)
        {
            verif = false;

            StartCoroutine(CoroutinePassif());

            verif = true;
        }

        if (membre.etat == MembreEquipage.EnumEquipages.ePathFinding && !enPAth)
        {

            if (vEnnemi)
            {
                MettreAJourVaisseau();
                StartCoroutine(Pathfinder(membre.tuile.Position, membre.cible));
                
                Debug.Log("Ennemi yeah SHeshhh");
            }

            if (!vEnnemi)
            {
                MettreAJourVaisseau();
                StartCoroutine(Pathfinder(membre.tuile.Position, membre.cible));
                Debug.Log("Gentil pas cancer je joue pas a lol");
            }
        }

    }

    IEnumerator CoroutinePassif()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            direction.Normalize();
            yield return new WaitForSeconds(Random.Range(1.5f, 3f));
            direction = Vector2.zero;
            yield return new WaitForSeconds(Random.Range(2.0f, 4f));
        }
    }

    private IEnumerator Pathfinder(Vector2 positionDepart, Vector2 positionFin)
    {

        dicOPEN = new Dictionary<int, (HPT, int)>();
        dicCLOSE = new Dictionary<int, (HPT, int)>();

        trouver = false;
        List<HPT> pathHPT = new List<HPT>();
        pathHPT = GenererHPT(positionDepart, positionFin);

        while (!trouver)
        {
            HPT current = new HPT();

            var min = dicOPEN.Aggregate((l, r) => l.Value.Item2 < r.Value.Item2 ? l : r).Key;

            current = dicOPEN[min].Item1;

            dicOPEN.Remove(min);

            dicCLOSE.Add(compteur,(current,current.setT()));
            compteur++;

            if (current.maPosition == positionFin)
            {
                Debug.Log("chemin trouver");
                StartCoroutine(TrouverListeChemin(current));
                trouver = true;
                enPAth = true;
            }

            List<HPT> mesVoisinsdic = TrouverVoisin(current, pathHPT);

            foreach (HPT voisin in mesVoisinsdic)
            {
                bool contientmaispluspetit = false;
                bool estdejala = false;

                List<int> keysCLOSE = (from kvp in dicCLOSE where kvp.Value.Item1 == voisin select kvp.Key).ToList();
                foreach (int cle in keysCLOSE)
                {
                    if (!voisin.traversable || dicCLOSE.ContainsKey(cle))
                    {
                        estdejala = true;
                    }
                }

                if((!voisin.traversable && !voisin.fin) || estdejala)
                {
                    continue;
                }

                List<int> keysOPEN = (from kvp in dicOPEN where kvp.Value.Item1 == voisin select kvp.Key).ToList();
                
                if (keysOPEN.Count > 0)
                {
                    foreach (int cle in keysOPEN)
                    {
                        if (dicOPEN[cle].Item2 > voisin.setT())
                        {
                            contientmaispluspetit = true;
                        }
                    }
                }

                if (keysOPEN.Count == 0 || contientmaispluspetit)
                {
                    voisin.parent = current;
                    dicOPEN.Add(compteur, (voisin, voisin.setT()));
                    compteur++;
                }
            }
            if (dicOPEN.Count() == 0)
            {
                trouver = true;
                Debug.Log("chemin impossible");
                membre.etat = MembreEquipage.EnumEquipages.ePassif;
            }
        }

        yield break;
    }

    private IEnumerator TrouverListeChemin(HPT chemin)
    {
        if (!chemin.debut)
        {
            if (vecteurDeplacement == null)
            {
                vecteurDeplacement = new List<(Vector2, string,Sol)>();
            }
            StartCoroutine(TrouverListeChemin(chemin.parent));
            vecteurDeplacement.Add((chemin.tileposition, chemin.nom,chemin.solpresent));
        }
        else
        {
            parentFinalTrouver = true;
        }

        yield break;
    }

    private List<HPT> TrouverVoisin(HPT current, List<HPT> tout)
    {
        List<HPT> mesvoisins = new List<HPT>();
        foreach (HPT v in tout)
        {
            // bool un = false;
            bool deux = false;
            bool trois = false;

            //if (((current.maPosition.x - v.maPosition.x) == 1  || (current.maPosition.x - v.maPosition.x) == -1) && ((current.maPosition.y - v.maPosition.y) == 1 || (current.maPosition.y - v.maPosition.y) == -1)) { un = true;}

            if (((current.maPosition.x - v.maPosition.x) == 1 || (current.maPosition.x - v.maPosition.x) == -1) && ((current.maPosition.y - v.maPosition.y) == 0 || (current.maPosition.y - v.maPosition.y) == 0))
            {
                deux = true;
            }

            if (((current.maPosition.x - v.maPosition.x) == 0 || (current.maPosition.x - v.maPosition.x) == 0) && ((current.maPosition.y - v.maPosition.y) == 1 || (current.maPosition.y - v.maPosition.y) == -1))
            {
                trois = true;
            }

            if ((deux || trois))
            {
                v.H = 10 + current.H;
                mesvoisins.Add(v);
            }

            /*if (un) { v.H = 14 + current.H; mesvoisins.Add(v); }*/
            MettreAJOURPTVoisin(mesvoisins, tout);
        }
        return mesvoisins;
    }

    private void MettreAJOURPTVoisin(List<HPT> voisin, List<HPT> fin)
    {
        HPT distanceFin = new HPT();

        foreach (HPT t in fin)
        {
            if (t.fin)
            {
                distanceFin = t;
            }
        }

        foreach (HPT PT in voisin)
        {
            int ajoutP = 0;

            float x = distanceFin.maPosition.x - PT.maPosition.x;
            float y = distanceFin.maPosition.y - PT.maPosition.y;
            double restex = System.Math.Truncate(x);
            double restey = System.Math.Truncate(y);

            double foisx = restex / 17.8;
            int floorx = (int)foisx;

            double foisy = restey / 17.8;
            int floory = (int)foisy;

            if (floorx > floory)
            {
                int howmany = floorx - floory;
                ajoutP = (howmany * 10) + (14 * floory);
            }

            else if (floory > floorx)
            {
                int howmany = floory - floorx;
                ajoutP = (howmany * 10) + (14 * floorx);
            }

            else if (floorx == floory)
            {
                int howmany = floorx;
                ajoutP = howmany * 14;
            }

            PT.P = ajoutP;
            PT.setT();
        }
    }

    private List<HPT> GenererHPT(Vector2 positionDepart, Vector2 positionFin)
    {

        List<HPT> listHPT = new List<HPT>();
        List<Tile> copy = new();

        if (vEnnemi) { copy = tilepathEnnemi;}

        if (!vEnnemi) { copy = tilepath;}

        foreach (Tile iteration in copy)
        {
            if (iteration.Position == positionDepart)
            {
                HPT depart = new HPT();
                depart.maPosition = iteration.Position;
                depart.tileposition = iteration.gameObject.transform.position;
                depart.H = 0;
                depart.P = 0;
                depart.debut = true;
                depart.parent = null;
                depart.nom = iteration.name;
                if (iteration.Sol)
                {
                    depart.solpresent = iteration.GetComponent­<Sol>();
                }

                if (iteration.Traversable)
                {
                    depart.traversable = true;
                }

                else
                {
                    depart.traversable = false;
                }

                listHPT.Add(depart);
                dicOPEN.Add(compteur, (depart, depart.setT()));
                compteur++;
            }

            if (iteration.Position == positionFin)
            {
                HPT fin = new HPT();
                fin.maPosition = iteration.Position;
                fin.tileposition = iteration.gameObject.transform.position;
                fin.fin = true;
                fin.nom = iteration.name;

                if (iteration.Sol)
                {
                    fin.solpresent = iteration.GetComponent­<Sol>();
                }

                if (iteration.Traversable)
                {
                    fin.traversable = true;
                }

                else
                {
                    fin.traversable = false;
                }

                listHPT.Add(fin);
            }

            if (iteration.Position != positionDepart && iteration.Position != positionFin)
            {
                HPT ajout = new HPT();
                ajout.maPosition = iteration.Position;
                ajout.tileposition = iteration.gameObject.transform.position;
                ajout.nom = iteration.name;

                if (iteration.Sol)
                {
                    ajout.solpresent = iteration.GetComponent­<Sol>();
                }

                if (iteration.Traversable)
                {
                    ajout.traversable = true;
                }

                else
                {
                    ajout.traversable = false;
                }
                listHPT.Add(ajout);
            }
        }
        return listHPT;
    }

    public void MettreAJourVaisseau()
    {
        Component[] tuilesMechant;
        Component[] tuiles;

        if (vEnnemi)
        {
            vaisseauEnnemi = GameObject.Find("VaisseauEnnemi");
            tuilesMechant = vaisseauEnnemi.transform.GetChild(0).gameObject.GetComponentsInChildren<Tile>();

            tilepathEnnemi = new List<Tile>();

            foreach (Tile tuile in tuilesMechant)
            {
                tilepathEnnemi.Add(tuile);
            }

            TestEnnemi = vaisseauEnnemi.GetComponent<Vaisseau>();
        }

        else
        {
            vaisseau = GameObject.Find("Vaisseau");
            tuiles = GameObject.Find("Tuiles").GetComponentsInChildren<Tile>();

            tilepath = new List<Tile>();

            foreach (Tile tuile in tuiles)
            {
                tilepath.Add(tuile);
            }

            Test = vaisseau.GetComponent<Vaisseau>();
        }
    }
}

internal class HPT
{
    public Vector2 maPosition { get; set; }
    public Vector2 tileposition { get; set; }
    public string nom { get; set; }
    public int H { get; set; }
    public int P { get; set; }
    private int T;
    public bool debut { get; set; }
    public bool fin { get; set; }
    public Sol solpresent { get; set; }
    public HPT parent { get; set; }
    public bool traversable { get; set; }
    public int setT()
    {
        T = H + P;
        return T;
    }
}