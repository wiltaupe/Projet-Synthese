using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Partie : MonoBehaviour
{
    private bool partieEnCours = false;
    private Joueur joueur;
    private Vaisseau vaisseauJoueur;
    private CarteCeleste carteActuelle;
    private int niveauActuel;
    private bool enCombat = false;

    // 11 23 35 41 47



    // Start is called before the first frame update
    void Start()
    {
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
        if (partieEnCours == false && joueur != null)
        {
            partieEnCours = true;
            joueur.AjouterVaisseau(gameObject.AddComponent<Vaisseau>());
            carteActuelle = gameObject.AddComponent<CarteCeleste>();
        }
    }

    public void DemarrerCombat()
    {
        if (!enCombat)
        {
            CommencerCombat();
            enCombat = true;
            SceneManager.LoadSceneAsync()
        }
    }

    public void TerminerCombat()
    {
        if (enCombat)
        {
            enCombat = false;

        }
    }

    private void CommencerCombat()
    {
        throw new NotImplementedException();
    }

    public void ProchainNiveau()
    {
        niveauActuel++;
        carteActuelle = gameObject.AddComponent<CarteCeleste>();
    }
}
