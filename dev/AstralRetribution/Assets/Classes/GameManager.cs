using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private State _currentState;
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _currentState = new BeginState();
        _currentState.Start();

    }

    public void SetState(State state)
    {
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
        SceneManager.LoadScene("AstralRetribution_MenuInitial");
    }





}
