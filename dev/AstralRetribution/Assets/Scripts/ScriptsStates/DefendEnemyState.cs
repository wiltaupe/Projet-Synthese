using System;
using System.Collections;
using UnityEngine;

internal class DefendEnemyState : State
{
    private GameManager gameManager;

    public DefendEnemyState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public override IEnumerator Start()
    {
        Debug.Log("DefendEnemyState");
        ProtectSalle(gameManager.VaisseauEnnemi.GetComponent<Vaisseau>().GetMostDamagedSalle());
        yield return new WaitForSeconds(1.0f);
        gameManager.SetState(new PlayerTurnState(gameManager));
    }

    private void ProtectSalle(Salle salle)
    {
        
    }
}