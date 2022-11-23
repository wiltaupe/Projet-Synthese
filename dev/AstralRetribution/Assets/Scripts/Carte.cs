using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Carte : MonoBehaviour,ISelectHandler
{
    public string description;
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



    private void GameManager_OnPlayerTurnEnd()
    {
        Button.interactable = false;
        
    }

    private void GameManager_OnPlayerTurn()
    {
        Button.interactable = true;
    }

    public void OnSelect(BaseEventData eventData)
    {
        GameManager.Instance.currentSelected = this;
    }
}