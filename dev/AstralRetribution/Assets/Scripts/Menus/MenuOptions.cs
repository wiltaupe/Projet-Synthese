using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public void Quitter()
    {
        SceneManager.LoadSceneAsync("MenuInitial");
    }
}
