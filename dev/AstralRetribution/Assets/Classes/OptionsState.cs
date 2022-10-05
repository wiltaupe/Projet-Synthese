using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class OptionsState : State
{
    

    public override void Start()
    {

        SceneManager.LoadScene("AstralRetribution_MenuOption");
        
    }
}