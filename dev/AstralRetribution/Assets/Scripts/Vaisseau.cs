using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Vaisseau : MonoBehaviour
{
    public List<Salle> Salles { get; set; }
    public List<GameObject> MembresEquipage { get; set; }

    public List<GameObject> MembreClone { get; set; } = new List<GameObject>();
    public List<Module> ModulesActifs { get; set; }
    public Vestige vestigeCourrant { get; set; }

    public float esquive = 0.1f;
    public GameObject tuiles;
    public bool possedeCloneur;
    public bool possedeTeleporteur { get; set; } = false;
    public bool possedeRecepteur { get; set; } = false;
    public bool possedeTeleporteurRecepteur { get; set; } = false;
    public Vector2 solRecepteur { get; set; } = new Vector2();
    public Vector2 positionRecepteur { get; set; } = new Vector2();
    public Vector2 solTeleporteur { get; set; } = new Vector2();
    public Vector2 positionTeleporteur { get; set; } = new Vector2();
    private bool enConstruction = true;
    public Module Teleporteur { get; set; }
    public Module Recepteur { get; set; }

    internal void AjoutEsquive(float pourcentageEsquive)
    {
        Debug.Log(pourcentageEsquive);
        esquive += pourcentageEsquive;
        Debug.Log(esquive);
    }

    internal Salle GetRandomSalle()
    {
        return Salles[Random.Range(0, Salles.Count)];
    }

    internal Salle GetMostDamagedSalle()
    {

        float mostDamaged = Salles[0].CurrentVie / Salles[0].MaxVie;
        Salle mostDamagedSalle = Salles[0];

        foreach (Salle salle in Salles)
        {
            float ratioVie = salle.CurrentVie / salle.MaxVie;
            if ( ratioVie < mostDamaged)
            {
                mostDamaged = ratioVie;
                mostDamagedSalle = salle;
            }

        }

        return mostDamagedSalle;
    }

    internal GameObject GetRandomMembre()
    {
        return MembresEquipage[Random.Range(0, MembresEquipage.Count)];
    }

    internal Module GetRandomModule()
    {
        return ModulesActifs[Random.Range(0, ModulesActifs.Count)];
    }

    internal Salle GetRandomDamagedSalle()
    {
        foreach (Salle salle in Salles)
        {
            if (salle.CurrentVie < salle.MaxVie)
            {
                return salle;
            }
        }

        return null;
    }

    internal bool SalleEndommagee()
    {
        foreach (Salle salle in Salles)
        {
            if (salle.CurrentVie < salle.MaxVie)
            {
                return true;
            }
        }
        return false;
    }

    // Start is called before the first frame update

    private void Awake()
    {
        ModulesActifs = new();
    }
    // Update is called once per frame
    void Update()
    {
        if(vestigeCourrant != null && enConstruction)
        {
            enConstruction = false;
            StartCoroutine(AjoutConstruction());
        }
    }

    private IEnumerator AjoutConstruction()
    {
        yield return new WaitForSeconds(2);
        if (vestigeCourrant.BuildCurrent != vestigeCourrant.BuildMax)
        {
            vestigeCourrant.BuildCurrent += 1;
        }
        enConstruction = true;
    }

    internal Sol GetRandomAvailableTile()
    {

        int choice = Random.Range(0, Salles.Count);
        Salle salle = Salles[choice];

        int rand = Random.Range(0, salle.Tuiles.Count);


        Sol sol = salle.Tuiles[rand];


        if (sol.Module != null || sol.MembreEquipage != null)
        {
            sol = null;
            return sol;
        }

        return sol;

    }

    internal void AddModule(Module module)
    {
        if (ModulesActifs.Contains(module))
        {
            return;
        }

        ModulesActifs.Add(module);
    }

    private void OnMouseDown()
    {
        if (tuiles.activeInHierarchy)
        {
            tuiles.SetActive(false);
        }
        else
        {
            tuiles.SetActive(true);
        }
    }

    public void VerifTelRec()
    {
        if (possedeTeleporteur && possedeRecepteur)
        {
            possedeTeleporteurRecepteur = true;
        }

        else
        {
            possedeTeleporteurRecepteur = false;
        }

    }

    internal void SwitchTeleporteur()
    {
        VerifTelRec();
        if (possedeTeleporteurRecepteur)
        {
            Vector3 posRecepteur = Recepteur.gameObject.transform.position;
            Vector3 posTeleporteur = Teleporteur.gameObject.transform.position;
            Teleporteur.gameObject.transform.position = posRecepteur;
            Recepteur.gameObject.transform.position = posTeleporteur;

            GameObject TileRecepteur = Recepteur.currentTile.gameObject;
            GameObject TileTeleporteur = Teleporteur.currentTile.gameObject;
            Teleporteur.gameObject.transform.SetParent(TileRecepteur.transform);
            Recepteur.gameObject.transform.SetParent(TileTeleporteur.transform);

            Vector2 solRec = Recepteur.currentTile.Position;
            Vector2 solTel = Teleporteur.currentTile.Position;
            solTeleporteur = solRec;
            solRecepteur = solTel;

            Vector2 vecRecepteur = positionRecepteur;
            Vector2 vecTeleporteur = positionTeleporteur;
            positionRecepteur = vecTeleporteur;
            positionTeleporteur = vecRecepteur;
        }
    }

    internal void PlacerVestige(GameObject v)
    {
        float ajustersize = (float)10 / (float)ShipManager.Taille;

        GameObject mod = Instantiate(v, transform.position, Quaternion.identity);
        mod.transform.localScale = new Vector3(ajustersize / 1.25f, ajustersize / 1.25f, 0);
        mod.GetComponent<Module>().Draggable = false;
        mod.GetComponent<Module>().Vaisseau = this;
        ModulesActifs.Add(mod.GetComponent<Module>());

        Sol tuile = null;
        while (tuile == null)
        {
            tuile = GetRandomAvailableTile();
        }

        mod.transform.SetParent(tuile.transform);
        mod.transform.position = tuile.transform.position;

        mod.GetComponent<Module>().currentTile = tuile;
        mod.GetComponent<Module>().Ennemi = false;

        tuile.Module = mod.GetComponent<Module>();
        vestigeCourrant = mod.GetComponent<Vestige>();
    }

    internal void ajoutModuleRecepteur(Sol sol,Module module)
    {
        possedeRecepteur = true;
        VerifTelRec();
        positionRecepteur = sol.transform.position;
        solRecepteur = sol.Position;
        Recepteur = module;
    }

    internal void ajoutModuleTeleporteur(Sol sol,Module module)
    {
        possedeTeleporteur = true;
        VerifTelRec();
        positionTeleporteur = sol.transform.position;
        solTeleporteur = sol.Position;
        Teleporteur = module;
    }

    internal void ajoutModuleCloneur()
    {
        possedeCloneur = true;
    }

    internal IEnumerator EnvoyerClone()
    {
        foreach (GameObject clone in MembreClone)
        {
            MembreEquipage membreClone = clone.GetComponent<MembreEquipage>();

            if (membreClone.ennemi)
            {
                if (possedeTeleporteur)
                {
                    membreClone.etat = MembreEquipage.EnumEquipages.ePathFindingEnnemi;
                    membreClone.cible = solTeleporteur;
                }
            }

            else
            {
                if (possedeTeleporteur)
                {
                    membreClone.etat = MembreEquipage.EnumEquipages.ePathFinding;
                    membreClone.cible = solTeleporteur;
                }
            }
        }

        yield break;
    }
}
