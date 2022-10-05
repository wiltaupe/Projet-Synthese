using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class OptionsState : State
{

    public override void Start()
    {
        SceneManager.LoadScene("AstralRetribution_MenuOption");

        /*GameObject canvas = GameObject.Find("Canvas");
        Debug.Log(canvas.GetComponentInChildren<Button>());
        canvas.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
        canvas.GetComponentInChildren<Button>().onClick.AddListener(() =>
        {
            _gameManager.QuitterOptions();
        });*/
    }
}