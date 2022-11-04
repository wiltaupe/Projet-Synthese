internal class PlayerTurnState : State
{
    private GameManager gameManager;

    public PlayerTurnState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public override void Start()
    {
        gameManager.Slider.PlayerTurn = true;
    }

}