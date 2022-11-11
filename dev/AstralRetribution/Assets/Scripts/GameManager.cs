using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public State currentState;
    public Transform posJoueur;
    public Transform posEnnemi;
    public GameObject VaisseauJoueur { get; set; }
    public GameObject VaisseauEnnemi { get; set; }
    public SliderScript Slider { get; set; }
    public Deck deckJoueur { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        Slider = FindObjectOfType<SliderScript>();
        currentState = new BeginState(this);
        currentState.Start();
    }

    public void SetState(State gameState)
    {
        currentState = gameState;
        currentState.Start();
        Debug.Log(currentState);
    }

    public void PlayerTurnEnd()
    {
        SetState(new EnemyTurnState(this));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RetourHub()
    {
        SceneManager.LoadSceneAsync("MenuHub");
    }
}
