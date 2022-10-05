using UnityEngine;

public class BeginState : State
{

    public override void Start()
    {
        
    }

    public override void Options()
    {
        GameManager.Instance.SetState(new OptionsState());
    }

    public override void DemarrerPartie()
    {
        GameManager.Instance.SetState(new ChoixPieceState());
    }

    public override void QuitterPartie()
    {
        Application.Quit();
    }

}