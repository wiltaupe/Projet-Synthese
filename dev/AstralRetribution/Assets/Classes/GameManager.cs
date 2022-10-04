using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private State _currentState;


    private void Start()
    {
        _currentState = new BeginState(this);
        _currentState.Start();

    }

    public void SetState(State state)
    {
        Debug.Log(state);
        _currentState = state;
        _currentState.Start();
    }

    public void DemarrerPartie()
    {
        _currentState.DemarrerPartie();
    }

    public void Options()
    {
        _currentState.Options();
    }

    public void Quitter()
    {
        _currentState.QuitterPartie();
    }

    public void QuitterOptions()
    {
        Debug.Log("salut");
        SceneManager.LoadScene("AstralRetribution_MenuInitial");
    }





}
