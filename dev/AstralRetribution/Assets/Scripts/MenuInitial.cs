using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInitial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
