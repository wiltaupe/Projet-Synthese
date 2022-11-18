using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private State currentState;
    [field: SerializeField] public Transform posJoueur { get; set; }
    [field: SerializeField] public Transform posEnnemi { get; set; }
    [field: SerializeField] public GameObject deckContainer { get; set; }

    public GameObject VaisseauJoueur { get; set; }
    public GameObject VaisseauEnnemi { get; set; }
    public SliderScript Slider { get; set; }
    [HideInInspector] public Deck DeckJoueur { get; set; }
    private int cartesParTour = 4;
    private System.Random random = new();

    public void AfficherDeck()
    {
        int compteur = 0;
        
        
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

        


        /*foreach (GameObject carte in DeckJoueur.Cartes)
        {
            Instantiate(carte, deckContainer.transform);
            

        }*/
    }

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
