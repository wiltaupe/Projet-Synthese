using System;
using UnityEngine;
using UnityEngine.UI;

public class Carte : MonoBehaviour
{
    public string description;
    

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
    void OnClick()
    {
        Debug.Log("sa marche");
    }

    private void OnEnable()
    {
        GameManager.OnPlayerTurn += GameManager_OnPlayerTurn;
        GameManager.OnPlayerTurnEnd += GameManager_OnEnnemyTurn;
    }

    private void OnDisable()
    {
        GameManager.OnPlayerTurn -= GameManager_OnPlayerTurn;
        GameManager.OnPlayerTurnEnd -= GameManager_OnEnnemyTurn;
    }

    private void GameManager_OnPlayerTurn()
    {
        GetComponent<Button>().interactable = true;
    }

    private void GameManager_OnEnnemyTurn()
    {
        GetComponent<Button>().interactable = false;
    }

}