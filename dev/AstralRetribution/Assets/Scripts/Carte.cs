using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Carte : MonoBehaviour,ISelectHandler
{
    public string description;
    public bool selected = false;
    [field:SerializeField] public Button Button { get; set; }

    void OnEnable()
    {
        GameManager.OnPlayerTurn += GameManager_OnPlayerTurn;
        GameManager.OnPlayerTurnEnd += GameManager_OnPlayerTurnEnd;
        GameManager.OnCardPlayed += GameManage_OnCardPlayed;
    }

    private void GameManage_OnCardPlayed(Carte carte)
    {
        Button.interactable = false;
    }

    void OnDisable()
    {
        GameManager.OnPlayerTurn -= GameManager_OnPlayerTurn;
        GameManager.OnPlayerTurnEnd -= GameManager_OnPlayerTurnEnd;
    }

    public virtual void PlayCard()
    {

    }

    public virtual void PlayCard(Salle cible)
    {

    }


    public void GameManager_OnPlayerTurnEnd()
    {
        Button.interactable = false;
    }

    private void GameManager_OnPlayerTurn()
    {
        Button.interactable = true;
    }

    public void OnSelect(BaseEventData eventData)
    {
        GameManager.Instance.carteSelected = this;
    }

    
}