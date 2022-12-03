using System.Collections;
using UnityEngine;

internal class AttackEnemyState : State
{
    private GameManager gameManager;

    public AttackEnemyState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public override IEnumerator Start()
    {
        Debug.Log("AttackEnemyState");
        yield break;
    }
}