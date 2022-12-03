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
        yield break;
    }

    private void ProtectSalle(Salle salle)
    {
        
    }
}