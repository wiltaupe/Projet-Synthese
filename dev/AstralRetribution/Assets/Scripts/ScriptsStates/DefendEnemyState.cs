using System;

internal class DefendEnemyState : State
{
    private GameManager gameManager;

    public DefendEnemyState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public override void Start()
    {

        ProtectSalle(gameManager.VaisseauEnnemi.GetComponent<Vaisseau>().GetMostDamagedSalle());

    }

    private void ProtectSalle(Salle salle)
    {

    }
}