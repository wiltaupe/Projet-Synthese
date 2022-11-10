using System.Collections.Generic;
using UnityEngine;

public class Vaisseau : MonoBehaviour
{
    public List<Salle> Salles { get; set; }
    public List<GameObject> MembresEquipage { get; set; }
    public List<Module> ModulesActifs { get; set; }
    // Start is called before the first frame update

    private void Awake()
    {
        ModulesActifs = new();
    }
    // Update is called once per frame
    void Update()
    {

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
        Debug.Log(ModulesActifs.Count);
    }
}
