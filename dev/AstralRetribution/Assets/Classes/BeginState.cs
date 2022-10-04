using UnityEngine;

public class BeginState : State
{


    public BeginState(GameManager gameManager) : base(gameManager)
    {
       
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Options()
    {
        _gameManager.SetState(new OptionsState(_gameManager));
    }

    public override void DemarrerPartie()
    {
        _gameManager.SetState(new GameState(_gameManager));
    }

    public override void QuitterPartie()
    {
        Application.Quit();
    }

}