using System.Collections;
using UnityEngine;

internal class AttackEnemyState : State
{
    private readonly GameManager gameManager;
    private readonly float degats = 15;

    public AttackEnemyState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public override IEnumerator Start()
    {
        Salle salle = gameManager.VaisseauJoueur.GetComponent<Vaisseau>().GetRandomSalle();
        salle.RecevoirDegats(degats);
        gameManager.LancerMissile(salle);
        yield return new WaitForSeconds(1f);
        gameManager.SetState(new PlayerTurnState(gameManager));
    }
}