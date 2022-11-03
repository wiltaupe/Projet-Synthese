using UnityEngine;

public class BeginState : State
{
    private GameManager gameManager;

    public BeginState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }


    public override void Start()
    {
        gameManager.VaisseauJoueur = GameObject.Find("Vaisseau");
        gameManager.VaisseauJoueur.transform.position = gameManager.posJoueur.position;
        gameManager.VaisseauJoueur.transform.localScale = new Vector2(1.05f, 1.05f);

       

        gameManager.VaisseauEnnemi = MainManager.Instance.ShipManager.GenererVaisseau(gameManager.posEnnemi.position, true).gameObject;
        gameManager.VaisseauEnnemi.transform.localScale = new Vector2(1.05f, 1.05f);

        gameManager.SetState(new PlayerTurnState(gameManager));
    }
}