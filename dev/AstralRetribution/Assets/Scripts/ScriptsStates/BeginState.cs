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
        InitVaisseaux();
        GenererDeck();

        

        gameManager.SetState(new PlayerTurnState(gameManager));

        yield break;
    }

    private void GenererDeck()
    {
        Deck deck = new();
        int compteur = 0;
        Vaisseau vaisseauJoueur = gameManager.VaisseauJoueur.GetComponent<Vaisseau>();
        foreach (Module module in vaisseauJoueur.ModulesActifs)
        {
            if (module.Type == Module.Etat.actif)
            {
                GameObject prefabCarte = module.Prefab;
                for (int i = 0; i < module.nbCartes; i++)
                {
                    
                    deck.Cartes.Add(compteur, UnityEngine.Object.Instantiate(prefabCarte,gameManager.DeckContainer.transform));
                    compteur++;
                }
            }
            
        }

        gameManager.DeckJoueur = deck;
    }

    private void InitVaisseaux()
    {
        gameManager.VaisseauJoueur = GameObject.Find("Vaisseau");
        gameManager.VaisseauJoueur.transform.position = gameManager.PosJoueur.position;
        gameManager.VaisseauJoueur.GetComponent<Vaisseau>().tuiles.SetActive(true);

        gameManager.VaisseauEnnemi = MainManager.Instance.ShipManager.GenererVaisseau(gameManager.PosEnnemi.position, true).gameObject;
        gameManager.VaisseauEnnemi.transform.localScale = new Vector3(2.75f, 2.75f);
        MainManager.Instance.MemberManager.GenererMembres(UnityEngine.Random.Range(4,8), gameManager.VaisseauEnnemi.GetComponent<Vaisseau>(),true);
        MainManager.Instance.GenererModules(3,gameManager.VaisseauEnnemi.GetComponent<Vaisseau>(), true);
        gameManager.VaisseauEnnemi.GetComponent<Vaisseau>().tuiles.SetActive(true);

        gameManager.VaisseauEnnemi.GetComponent<Collider2D>().enabled = false;
        gameManager.VaisseauJoueur.GetComponent<Collider2D>().enabled = false;
    }
}