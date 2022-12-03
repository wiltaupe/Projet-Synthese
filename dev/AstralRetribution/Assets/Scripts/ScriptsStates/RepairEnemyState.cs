using System;
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
    public override void Start()
    {
        SelectRandomMembre();
        SelectRandomSalle();

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