using System.Collections;
using UnityEngine.SceneManagement;

internal class PlayerWinState : State
{
    private readonly GameManager gameManager;

    public PlayerWinState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public override IEnumerator Start()
    {
        SceneManager.LoadScene(3);
        yield break;
    }
}