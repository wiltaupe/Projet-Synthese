using System;
using System.Collections;
using UnityEngine;

public class RepairEnemyState : State
{
    private GameManager gameManager;
    private GameObject membre;
    private Salle cible; 
    public RepairEnemyState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public override IEnumerator Start()
    {
        SelectRandomMembre();
        SelectRandomSalle();
        yield return new WaitForSeconds(1.0f);
        gameManager.SetState(new PlayerTurnState(gameManager));
    }

    private void SelectRandomMembre()
    {
        membre = gameManager.VaisseauEnnemi.GetComponent<Vaisseau>().GetRandomMembre();
    }

    private void SelectRandomSalle()
    {
        cible = gameManager.VaisseauEnnemi.GetComponent<Vaisseau>().GetRandomDamagedSalle();
    }
}