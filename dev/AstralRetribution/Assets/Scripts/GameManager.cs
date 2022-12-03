using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [field:SerializeField]public GameObject Bullet { get; set; }
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
    private readonly System.Random random = new();
    [HideInInspector]public Salle RoomSelected { get; set; }
    [HideInInspector]public Carte CarteSelected { get; set; }


    public void Awake()
    {
        Instance = this;
    }

    public void LancerMissile(Salle cible)
    {
        Instantiate(Bullet, cible.GetMiddleSol().transform.position, Quaternion.identity);
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
        StartCoroutine(currentState.Start());
        
    }

    internal void CardPlayed()
    {
        OnCardPlayed?.Invoke(CarteSelected);
    }

    public void PlayerTurn()
    {
        OnPlayerTurn?.Invoke();
    }

    public void SetState(State gameState)
    {
        currentState = gameState;
        StartCoroutine(currentState.Start());
    }

    public void PlayerTurnEnd()
    {
        OnPlayerTurnEnd?.Invoke();
        PlayCard();
        RoomSelected = null;
        CarteSelected = null;

        SetState(new EnemyTurnState(this));
    }

    private void PlayCard()
    {
        if (RoomSelected != null)
        {
            currentState.PlayCard(CarteSelected, RoomSelected);
        }
        else
        {
            currentState.PlayCard(CarteSelected);
        }
    }

    public void RetourHub()
    {
        SceneManager.LoadSceneAsync("MenuHub");
    }
}
