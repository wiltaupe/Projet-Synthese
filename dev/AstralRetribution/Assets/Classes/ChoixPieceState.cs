internal class ChoixPieceState : State
{
    public override void Start()
    {
        base.Start();
    }

    public override void GenererVaisseau()
    {
        base.GenererVaisseau();
    }

    public override void DeplacerPiece()
    {

    }

    public void TerminerSelection()
    {
        GameManager.Instance.SetState(new GameState());
    }
}