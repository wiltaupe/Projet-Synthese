using UnityEngine;

public class Partie : MonoBehaviour
{
    private bool partieEnCours = false;
    private Joueur joueur;
    private CarteCeleste carteActuelle;
    private int niveauActuel;
    private bool enCombat = false;

    // 11 23 35 41 47



    // Start is called before the first frame update
    void Start()
    {
        joueur = new Joueur();
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
            GenererCarte();
        }
    }

    public void FinirPartie()
    {
        if (partieEnCours)
        {
            partieEnCours = false;
        }
    }

    public void GenererCarte()
    {
        carteActuelle = gameObject.AddComponent<CarteCeleste>();
    }

    

    public void DemarrerCombat()
    {
        if (!enCombat)
        {
            enCombat = true;
        }
    }

    public void TerminerCombat()
    {
        if (enCombat)
        {
            enCombat = false;
        }
    }

    public void ProchainNiveau()
    {
        niveauActuel++;
        GenererCarte();
    }
}
