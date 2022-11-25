using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public delegate void PlayerTurnAction();
    public static event PlayerTurnAction OnPlayerTurn;
    public delegate void PlayerTurnEndAction();
    public static event PlayerTurnEndAction OnPlayerTurnEnd;

    private State currentState;
    [field: SerializeField] public Transform posJoueur { get; set; }
    [field: SerializeField] public Transform posEnnemi { get; set; }
    [field: SerializeField] public GameObject deckContainer { get; set; }

    public GameObject VaisseauJoueur { get; set; }
    public GameObject VaisseauEnnemi { get; set; }
    [field:SerializeField] public SliderScript Slider { get; set; }
    [HideInInspector] public Deck DeckJoueur { get; set; }
    public int cartesParTour = 4;
    private System.Random random = new();
    public bool attackSelected = false;


    public void Awake()
    {
        Instance = this;
    }
    public void DrawCards()
    {
        int compteur = 0;
        if (cartesParTour > DeckJoueur.Cartes.Count)
        {
            cartesParTour = DeckJoueur.Cartes.Count;
        }


        while (compteur != cartesParTour)
        {
            int index = random.Next(DeckJoueur.Cartes.Count);
            DeckJoueur.Main.Add(DeckJoueur.Cartes[index]);
            DeckJoueur.Cartes.RemoveAt(index);
            compteur++;
        }

        foreach (GameObject carte in DeckJoueur.Main)
        {

            Instantiate(carte, deckContainer.transform);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        currentState = new BeginState(this);
        currentState.Start();
    }

    public void PlayerTurn()
    {
        OnPlayerTurn?.Invoke();
    }

    public void SetState(State gameState)
    {
        currentState = gameState;
        currentState.Start();
    }

    public void PlayerTurnEnd()
    {
        Debug.Log("fini");
        OnPlayerTurnEnd?.Invoke();

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
