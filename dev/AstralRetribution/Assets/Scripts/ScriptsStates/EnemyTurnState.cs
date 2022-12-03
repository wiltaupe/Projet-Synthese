using System;
using UnityEngine;

public class EnemyTurnState : State
{
    private GameManager gameManager;
    private State currentState = null;
    private float repairChance = 50f;

    public EnemyTurnState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public override void Start()
    {

        CheckCurrentState();   
    }

    private void CheckCurrentState()
    {
        if (gameManager.VaisseauEnnemi.GetComponent<Vaisseau>().SalleEndommagee())
        {
            if (UnityEngine.Random.Range(0, 100) <= repairChance)
            {
                SetState(new RepairEnemyState(gameManager));
            }
            else
            {
                SetState(new DefendEnemyState(gameManager));
            }


        }
        else
        {
            SetState(new AttackEnemyState(gameManager));
        }

    }

    private void SetState(State state)
    {

        currentState.Start();
    }




}