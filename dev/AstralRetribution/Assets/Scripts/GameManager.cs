using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public delegate void PlayerTurnAction();
    public static event PlayerTurnAction OnPlayerTurn;
    public delegate void PlayerTurnEndAction();

    public static event PlayerTurnEndAction OnPlayerTurnEnd;
    public delegate void CardPlayedAction(Carte carte);
    public static event CardPlayedAction OnCardPlayed;

    private State currentState;
    [field: SerializeField] public Transform PosJoueur { get; set; }
    [field: SerializeField] public Transform PosEnnemi { get; set; }
    [field: SerializeField] public GameObject DeckContainer { get; set; }

    public GameObject VaisseauJoueur { get; set; }
    public GameObject VaisseauEnnemi { get; set; }
    [field:SerializeField] public SliderScript Slider { get; set; }
    [HideInInspector] public Deck DeckJoueur { get; set; }
    public int cartesParTour = 4;
    private System.Random random = new();
    public Salle RoomSelected;
    public Carte carteSelected;


    public void Awake()
    {
        Instance = this;
    }

    public void LancerMissile(Salle cible)
    {
        Debug.Log(cible.GetMiddleTile());
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

            Instantiate(carte, DeckContainer.transform);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = new BeginState(this);
        currentState.Start();
    }

    internal void CardPlayed()
    {
        OnCardPlayed?.Invoke(carteSelected);
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
        OnPlayerTurnEnd?.Invoke();
        PlayCard();
        RoomSelected = null;
        carteSelected = null;

        SetState(new EnemyTurnState(this));
    }

    private void PlayCard()
    {
        if (RoomSelected != null)
        {
            currentState.PlayCard(carteSelected, RoomSelected);
        }
        else
        {
            currentState.PlayCard(carteSelected);
        }
    }

    public void RetourHub()
    {
        SceneManager.LoadSceneAsync("MenuHub");
    }
}
