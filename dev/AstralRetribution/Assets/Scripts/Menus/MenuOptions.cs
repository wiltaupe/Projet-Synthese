using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    // Start is called before the first frame update
    public void Quitter()
    {
        SceneManager.LoadSceneAsync("MenuInitial");
    }
}
