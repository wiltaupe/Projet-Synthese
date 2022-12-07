using System;
using System.Collections;
using UnityEngine;

public class EnemyTurnState : State
{
    private GameManager gameManager;
    private float repairChance = 50f;
    private float attackChanceWhileDammaged = 20f;

    public EnemyTurnState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public override IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        GameObject[] cartes = GameObject.FindGameObjectsWithTag("Carte");
        foreach (GameObject carte in cartes)
        {
            gameManager.DeckJoueur.Main.Remove(carte.GetComponent<Carte>().Idx);
            gameManager.DeckJoueur.Cartes[carte.GetComponent<Carte>().Idx] = carte;
            carte.SetActive(false);
        }
            
        
        CheckCurrentState();
    }

    private void CheckCurrentState()
    {
        if (gameManager.VaisseauEnnemi.GetComponent<Vaisseau>().SalleEndommagee())
        {
            if (UnityEngine.Random.Range(0, 100) <= repairChance)
            {
                gameManager.SetState(new RepairEnemyState(gameManager));
            }
            else if (UnityEngine.Random.Range(0, 100) <= attackChanceWhileDammaged)
            {
                gameManager.SetState(new AttackEnemyState(gameManager));
            }
            else
            {
                gameManager.SetState(new DefendEnemyState(gameManager));
            }


        }
        else
        {
            gameManager.SetState(new AttackEnemyState(gameManager));
        }

    }




}