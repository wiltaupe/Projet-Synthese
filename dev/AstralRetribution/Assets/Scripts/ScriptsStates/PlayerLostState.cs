using System.Collections;
using UnityEngine.SceneManagement;

internal class PlayerLostState : State
{
    private readonly GameManager gameManager;

    public PlayerLostState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public override IEnumerator Start()
    {
        SceneManager.LoadScene(6);
        yield break;
    }
}