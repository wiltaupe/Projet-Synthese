using System;
using UnityEngine;
using UnityEngine.UI;

public class Carte : MonoBehaviour
{
    public string description;

    private void OnEnable()
    {
        GameManager.OnPlayerTurn += GameManager_OnPlayerTurn;
        GameManager.OnEnnemyTurn += GameManager_OnEnnemyTurn;
    }

    private void OnDisable()
    {
        GameManager.OnPlayerTurn -= GameManager_OnPlayerTurn;
        GameManager.OnEnnemyTurn -= GameManager_OnEnnemyTurn;
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