public abstract class State
{
    protected readonly GameManager _gameManager;

    public State(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public virtual void Start()
    {

    }

    public virtual void DemarrerPartie()
    {

    }

    public virtual void QuitterPartie()
    {
        
    }

    public virtual void QuitterOptions()
    {

    }

    public virtual void Options()
    {

    }





}
