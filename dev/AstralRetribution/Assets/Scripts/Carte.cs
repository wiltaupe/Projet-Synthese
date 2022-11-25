using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Carte : MonoBehaviour,ISelectHandler, IDeselectHandler
{
    public string description;
    public bool selected = false;
    [field:SerializeField] public Button Button { get; set; }

    void OnEnable()
    {
        GameManager.OnPlayerTurn += GameManager_OnPlayerTurn;
        GameManager.OnPlayerTurnEnd += GameManager_OnPlayerTurnEnd;
    }

    void OnDisable()
    {
        GameManager.OnPlayerTurn -= GameManager_OnPlayerTurn;
        GameManager.OnPlayerTurnEnd -= GameManager_OnPlayerTurnEnd;
    }

    public virtual void PlayCard()
    {

    }


    public void GameManager_OnPlayerTurnEnd()
    {
        
        if (selected)
        {
            PlayCard();
        }
        Button.interactable = false;


    }

    private void GameManager_OnPlayerTurn()
    {
        Button.interactable = true;
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (this is CartePilotage)
        {
            GameManager.Instance.attackSelected = true;
        }
        selected = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (this is CartePilotage)
        {
            GameManager.Instance.attackSelected = false;
        }
        selected = false;
    }
}