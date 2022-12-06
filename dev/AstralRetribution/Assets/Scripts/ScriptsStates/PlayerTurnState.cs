using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

internal class PlayerTurnState : State
{
    private GameManager gameManager;
    

    public PlayerTurnState(GameManager gameManager)
    {
        this.gameManager = gameManager;

    }

    public override IEnumerator Start()
    {
        Debug.Log("PlayerTurnState");
        gameManager.Slider.tour = 0;
        gameManager.Slider.PlayerTurn = true;
        gameManager.DrawCards();
        gameManager.PlayerTurn();

        yield break;
    }
        
        

    public override void PlayCard(Carte carte)
    {
        if (carte != null)
        {
            carte.PlayCard();
        }
    }

    public override void PlayCard(Carte carte, Salle cible)
    {
        carte.PlayCard(cible);
    }

}