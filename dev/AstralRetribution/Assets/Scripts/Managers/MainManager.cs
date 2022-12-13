using System;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public GameObject[] moduleObligatoire;
    public GameObject[] moduleSecondaire;
    public static MainManager Instance { get; private set; }

    public ShipManager ShipManager { get; private set; }

    public MemberManager MemberManager { get; private set; }
    public Sprite Background { get; set; }

    public Vaisseau VaisseauJoueur { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);

        ShipManager = GetComponentInChildren<ShipManager>();
        MemberManager = GetComponentInChildren<MemberManager>();
    }

    private void PlacerModule(GameObject module, Vaisseau vaisseau, bool ennemi)
    {
        Sol tuile = null;
        while (tuile == null)
        {
            tuile = vaisseau.GetRandomAvailableTile();
        }

        module.transform.SetParent(tuile.transform);
        module.transform.position = tuile.transform.position;

        module.GetComponent<Module>().currentTile = tuile;
        module.GetComponent<Module>().Ennemi = true;

        tuile.Module = module.GetComponent<Module>();
    }

    internal void GenererModules(int v1, Vaisseau vaisseau, bool v2)
    {
        if (v2)
        {
            float ajustersize = (float)10 / (float)ShipManager.Taille;

            foreach (GameObject module in moduleObligatoire)
            {
                GameObject mod = Instantiate(module, transform.position, Quaternion.identity);
                mod.transform.localScale = new Vector3(ajustersize/1.25f, ajustersize/1.25f, 0);
                mod.GetComponent<Module>().Draggable = false;
                mod.GetComponent<Module>().vaisseauEnnemi = vaisseau;

                PlacerModule(mod, vaisseau, v2);
            }

            int i = 0;

            while (i < v1)
            {
                GameObject selection = moduleSecondaire[UnityEngine.Random.Range(0, moduleSecondaire.Length)];
                GameObject mod = Instantiate(selection, transform.position, Quaternion.identity);
                mod.transform.localScale = new Vector3(ajustersize / 1.25f, ajustersize / 1.25f, 0);
                mod.GetComponent<Module>().Draggable = false;
                mod.GetComponent<Module>().vaisseauEnnemi = vaisseau;

                PlacerModule(mod, vaisseau, v2);
                i++;
            }
        }
    }
}
