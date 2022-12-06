using System.Collections.Generic;
using UnityEngine;

public class Vaisseau : MonoBehaviour
{
    public List<Salle> Salles { get; set; }
    public List<GameObject> MembresEquipage { get; set; }
    public List<Module> ModulesActifs { get; set; }
    public float esquive = 0;
    
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
}
