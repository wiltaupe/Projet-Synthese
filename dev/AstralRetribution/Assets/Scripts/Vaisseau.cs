using System.Collections.Generic;
using UnityEngine;

public class Vaisseau : MonoBehaviour
{
    public List<Salle> Salles { get; set; }
    public List<GameObject> MembresEquipage { get; set; }
    // Start is called before the first frame update

    private void Start()
    {

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



        if (sol.Module != null && sol.MembreEquipage != null)
        {
            sol = null;
            return sol;
        }


        return sol;

    }
}
