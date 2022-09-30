using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partie : MonoBehaviour
{
    private bool partieEnCours = false;
    private Joueur joueur;
    private GenerateurDeSalle generateurDeSalle;
    private Vaisseau vaisseauJoueur;
    // Start is called before the first frame update
    void Start()
    {
        generateurDeSalle = gameObject.AddComponent<GenerateurDeSalle>();
        CommencerPartie();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreerJoueur(Joueur joueur)
    {
        this.joueur = joueur;
    }

    public void CommencerPartie()
    {
        if (partieEnCours == false)
        {
            partieEnCours = true;
            vaisseauJoueur = gameObject.AddComponent<Vaisseau>();
            Debug.Log(vaisseauJoueur.VoirSalles());

        }
    }
}
