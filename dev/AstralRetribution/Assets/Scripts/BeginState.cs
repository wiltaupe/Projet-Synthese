using System;
using UnityEngine;

public class BeginState : State
{
    private GameManager gameManager;

    public BeginState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }


    public override void Start()
    {

        InitVaisseaux();
        GenererDeck();
        gameManager.AfficherDeck();


        gameManager.SetState(new PlayerTurnState(gameManager));

        
    }

    private void GenererDeck()
    {
        Deck deck = new();
        Vaisseau vaisseauJoueur = gameManager.VaisseauJoueur.GetComponent<Vaisseau>();
        foreach (Module module in vaisseauJoueur.ModulesActifs)
        {
            if (module.Type == Module.Etat.actif)
            {
                GameObject prefabCarte = module.Prefab;
                for (int i = 0; i < module.nbCartes; i++)
                {

                    deck.Cartes.Add(prefabCarte);
                }
            }
            
        }

        gameManager.DeckJoueur = deck;
    }

    private void InitVaisseaux()
    {
        gameManager.VaisseauJoueur = GameObject.Find("Vaisseau");
        gameManager.VaisseauJoueur.transform.position = gameManager.posJoueur.position;
        gameManager.VaisseauJoueur.transform.localScale = new Vector2(1.05f, 1.05f);



        gameManager.VaisseauEnnemi = MainManager.Instance.ShipManager.GenererVaisseau(gameManager.posEnnemi.position, true).gameObject;
        gameManager.VaisseauEnnemi.transform.localScale = new Vector2(1.05f, 1.05f);
    }
}