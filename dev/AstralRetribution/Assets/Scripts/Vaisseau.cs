using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Vaisseau : MonoBehaviour
{
    private List<Salle> salles;
    [SerializeField] private int taille;
    [SerializeField] private int nbIterations;
    // Start is called before the first frame update

    private void Start()
    {
        List<RectInt> Salles = MainManager.Instance.RoomManager.GenererSalles(taille, nbIterations);
        salles = MainManager.Instance.GridManager.AfficherSalles(Salles,taille);

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void GetTuile(Sol sol)
    {
        throw new NotImplementedException();
    }
}
