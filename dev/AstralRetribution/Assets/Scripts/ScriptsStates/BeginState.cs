using System;
using System.Collections;
using UnityEngine;

public class BeginState : State
{
    private GameManager gameManager;

    public BeginState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }


    public override IEnumerator Start()
    {
        Debug.Log("BeginState");
        InitVaisseaux();
        GenererDeck();

        

        gameManager.SetState(new PlayerTurnState(gameManager));

        yield break;
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
        gameManager.VaisseauJoueur.transform.position = gameManager.PosJoueur.position;
        gameManager.VaisseauJoueur.transform.localScale = new Vector3(0.9f, 0.9f, 1);



        gameManager.VaisseauEnnemi = MainManager.Instance.ShipManager.GenererVaisseau(gameManager.PosEnnemi.position, true).gameObject;
        MainManager.Instance.MemberManager.GenererMembres(UnityEngine.Random.Range(4,8), gameManager.VaisseauEnnemi.GetComponent<Vaisseau>(),true);
        MainManager.Instance.GenererModules(0,gameManager.VaisseauEnnemi.GetComponent<Vaisseau>(), true);
        gameManager.VaisseauEnnemi.transform.localScale = new Vector3(0.9f, 0.9f, 1);
    }
}