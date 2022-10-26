using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Vaisseau : MonoBehaviour
{
    private List<Salle> salles;
    private List<GameObject> membresEquipage;
    [SerializeField] private int taille;
    [SerializeField] private int nbIterations;
    // Start is called before the first frame update

    private void Start()
    {
        List<RectInt> Salles = MainManager.Instance.RoomManager.GenererSalles(taille, nbIterations);
        membresEquipage = new List<GameObject>();
        salles = MainManager.Instance.GridManager.AfficherSalles(Salles,taille,this);

        while (membresEquipage.Count != 3)
        {
            Sol sol = GetRandomAvailableTile();
            if (sol == null)
            {
                return;
            }

            membresEquipage.Add(MainManager.Instance.MemberManager.GenererMembre(sol));

        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }



    internal Sol GetRandomAvailableTile()
    {
        int choice = UnityEngine.Random.Range(0, salles.Count);
        Salle salle = salles[choice];
        Sol sol = null;

        if (salle.Tuiles.Count == 0)
        {
            return sol;
        }

        int rand = UnityEngine.Random.Range(0, salle.Tuiles.Count);


        sol = salle.Tuiles[rand];



        if(sol.Module != null && sol.MembreEquipage != null)
        {
            sol = null;
            return sol;
        }


        return sol;

    }
}
