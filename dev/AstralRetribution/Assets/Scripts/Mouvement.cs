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
    private List<HPT> OPEN;
    private List<HPT> CLOSE;
    private List<Tile> tilepath = new List<Tile>();

    private bool fini = true;

    public enum EnumEquipages
    {
        eInactif = 1,
        ePassif = 2,
        eDeplacement = 3,
        ePathFinding = 4
    };

    public EnumEquipages etat;

    // Start is called before the first frame update
    void Start()
    {

        Component[] tuiles = GameObject.Find("Tuiles").GetComponentsInChildren<Tile>();

        foreach (Tile tuile in tuiles)
        {
            tilepath.Add(tuile);
        }
        
       
        anim = this.GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        etat = EnumEquipages.ePassif;
    }

    // Update is called once per frame
    void Update()
    {
        if (deplacement())
        {
            anim.SetFloat("Horizontal", direction.x);
            anim.SetFloat("Vertical", direction.y);
            anim.SetFloat("Vitesse", direction.sqrMagnitude);

            //float vitesse = etat == EnumEquipages.eDeplacement ? vitesseChasse : vitessePatrouille;
            body.velocity = direction * vitesse;

            if (direction.sqrMagnitude > 0.1f)
            {
                anim.SetFloat("LastH", direction.x);
                anim.SetFloat("LastV", direction.y);
            }
            direction.Normalize();
        }

    }

    private bool deplacement()
    {
        // ePatrouille et eChasse
        return (etat & (EnumEquipages.eDeplacement | EnumEquipages.ePassif)) != 0;
    }


    void FixedUpdate()
    {

        if (etat == EnumEquipages.ePassif && !verif)
        {
            verif = false;
            StartCoroutine(CoroutinePassif());

            if (Random.Range(0, 2) == 1)
            {
                etat = EnumEquipages.ePathFinding;
            }

            verif = true;
        }

        if (etat == EnumEquipages.ePathFinding && fini)
        {
            //Debug.Log(body.transform.gameObject.GetComponent<MembreEquipage>().tuile.Position);

            //Debug.Log(MainManager.Instance.VaisseauJoueur.GetRandomAvailableTile().Position);
            fini = false;
            Pathfinder(body.transform.gameObject.GetComponent<MembreEquipage>().tuile.Position, body.transform.gameObject.GetComponent<MembreEquipage>().tuile.Position);
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

    private void Pathfinder(Vector2 positionDepart, Vector2 positionFin)
    {
        OPEN = new List<HPT>();
        CLOSE = new List<HPT>();

        bool trouver = false;

        List<HPT> pathHPT = new List<HPT>();
        pathHPT = GenererHPT(positionDepart, positionFin);

        while (!trouver)
        {

            List<float> Tvalue = new List<float>();
            HPT current = new HPT();

            foreach (HPT i in pathHPT)
            {
                Tvalue.Add(i.setT());
            }

            float minVal = Tvalue.Min();
            bool juste1 = true;

            foreach (HPT T in pathHPT)
            {
                if (T.setT() == minVal && juste1)
                {
                    current = T;
                    OPEN.Remove(current);
                    CLOSE.Add(current);
                    juste1 = false;
                }
            }


            if (current.maPosition == positionFin)
            {
                Debug.Log("position trouver");
                trouver = true;
            }

            Debug.Log("4");

            List<HPT> mesVoisins = TrouverVoisin(current, pathHPT);

            foreach (HPT voisin in mesVoisins)
            {
                if (!voisin.traversable || CLOSE.Contains(voisin))
                {
                    continue;
                }

                if (!OPEN.Contains(voisin) || voisin.setT() < current.setT()) // path voisin is shorter a voir
                {
                    // set parent of voisin to current
                    voisin.parent = current;

                    if (!OPEN.Contains(voisin))
                    {
                        OPEN.Add(voisin);
                    }
                }
            }

            trouver = true;
        }

    }

    private List<HPT> TrouverVoisin(HPT current, List<HPT> tout)
    {
        List<HPT> mesvoisins = new List<HPT>();
        foreach (HPT v in tout)
        {
            bool un = false;
            bool deux = false;
            if (((current.maPosition.x - v.maPosition.x) > 17 && (current.maPosition.x - v.maPosition.x) < 18) || ((current.maPosition.x - v.maPosition.x) > -17 && (current.maPosition.x - v.maPosition.x) < -18))
            {
                un = true;
            }

            if (((current.maPosition.y - v.maPosition.y) > 17 && (current.maPosition.y - v.maPosition.y) < 18) || ((current.maPosition.y - v.maPosition.y) > -17 && (current.maPosition.y - v.maPosition.y) < -18))
            {
                deux = true;
            }

            if ((un || deux) && !(un && deux))
            {
                v.H = 10 + current.H;
                mesvoisins.Add(v);
            }

            if (un && deux)
            {
                v.H = 14 + current.H;
                mesvoisins.Add(v);
            }

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
                double howmany = (floorx / floory);
                int f1 = (int)howmany;
                ajoutP = f1 * 14;
                ajoutP += 10;
                
            }

            else if (floorx > floory)
            {
                double howmany = (floory / floorx);
                int f2 = (int)howmany;
                ajoutP = f2 * 14;
                ajoutP += 10;
            }

            else if (floorx == floory)
            {
                double howmany = (floory / floorx);
                int f2 = (int)howmany;
                ajoutP = f2 * 14;
            }

            PT.P = ajoutP;
            PT.setT();
        }
    }

    private List<HPT> GenererHPT(Vector2 positionDepart,Vector2 positionFin)
    {
        List<HPT> listHPT = new List<HPT>();
        List<Tile> copy = tilepath;

        foreach (Tile iteration in copy)
        {

            if (iteration.Position == positionDepart)
            {
                HPT depart = new HPT();
                depart.maPosition = iteration.Position;
                depart.H = 0;
                depart.P = 0;
                depart.debut = true;

                if (iteration.Sol)
                {
                    depart.traversable = true;
                }

                else
                {
                    depart.traversable = false;
                }

                listHPT.Add(depart);
                OPEN.Add(depart);
            }

            if (iteration.Position == positionFin)
            {
                HPT fin = new HPT();
                fin.maPosition = iteration.Position;
                fin.fin = true;

                if (iteration.Sol)
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
                if (iteration.Sol)
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

    private void ResteHPT()
    {
        throw new System.NotImplementedException();
    }

}

internal class HPT
{
    public Vector2 maPosition { get; set; }
    public int H { get; set; }
    public int P { get; set; }
    private int T;
    public bool debut { get; set; }
    public bool fin { get; set; }

    public HPT parent { get; set; }

    public bool traversable { get; set; }

    public int setT()
    {
        T = H + P;
        return T;
    }

}