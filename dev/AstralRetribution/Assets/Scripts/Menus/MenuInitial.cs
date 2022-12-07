using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInitial : MonoBehaviour
{
    public void DemarrerPartie()
    {
        SceneManager.LoadSceneAsync("MenuSelection");
    }
    public void QuitterPartie()
    {
        Application.Quit();
    }
    public void Options()
    {
        SceneManager.LoadSceneAsync("MenuOption");
    }
}
