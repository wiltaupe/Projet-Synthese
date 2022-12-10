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
        yield return new WaitForSeconds(2.0f);
        Debug.Log("DefendEnemyState");
        ProtectSalle(gameManager.VaisseauEnnemi.GetComponent<Vaisseau>().GetMostDamagedSalle());
        
        gameManager.SetState(new PlayerTurnState(gameManager));
    }

    private void ProtectSalle(Salle salle)
    {
        salle.isProtected = true;
        foreach (Sol sol in salle.Tuiles)
        {
            sol.GetComponent<SpriteRenderer>().material.color = Color.blue;
            if (sol.Module != null)
            {
                sol.Module.Shield += 15;
            }
        }
    }
}