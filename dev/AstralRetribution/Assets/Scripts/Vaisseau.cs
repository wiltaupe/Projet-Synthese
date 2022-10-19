using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Vaisseau : MonoBehaviour
{
    public List<RectInt> salles { get; set; }
    public Tilemap sol, mur;
    public TileBase solBase;
    public TileBase murbase;
    public int taille;
    public int nbGenerations;
    // Start is called before the first frame update
    void Start()
    {
        Affichage();
    }

    private void Affichage()
    {
        GameObject gameObject = GameObject.Find("GenerateurSalle");
        GenerateurSalle generateurSalle = gameObject.GetComponent<GenerateurSalle>();
        salles = generateurSalle.GenererSalles(taille, nbGenerations);
        GameObject gameObjectAffichage = GameObject.Find("Afficher");
        Affichage afficher = gameObjectAffichage.GetComponent<Affichage>();
        afficher.AfficherSol(this,sol,solBase);
        afficher.AfficherMurs(this,mur,murbase);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
