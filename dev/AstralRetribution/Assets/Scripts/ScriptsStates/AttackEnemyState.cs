using System.Collections;
using UnityEngine;

internal class AttackEnemyState : State
{
    private readonly GameManager gameManager;
    private readonly float degats = 15;
    private float precision = 0.75f;

    public AttackEnemyState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public override IEnumerator Start()
    {
        Salle salle = gameManager.VaisseauJoueur.GetComponent<Vaisseau>().GetRandomSalle();
        if (Random.Range(0f, 1f) <= precision)
        {
            salle.RecevoirDegats(degats);
            GameManager.Instance.LancerMissile(salle);
        }
        else
        {
            GameManager.Instance.MissParticleSpawn(salle);
        }
        yield return new WaitForSeconds(1f);
        gameManager.SetState(new PlayerTurnState(gameManager));
    }
}