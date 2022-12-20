using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuEvenement : MonoBehaviour
{
    public Image background;
    GameObject vaisseau;
    public TextMeshProUGUI messageEvenement;
    public GameObject boutonOUI, boutonNON, boutonCombat, boutonHUB;
    public int choix;

    void Start()
    {

        choix = Random.Range(0, PlaneteManager.Instance.currentEvent.evenementEvent.background.Length);
        background.sprite = PlaneteManager.Instance.currentEvent.evenementEvent.background[choix];

        messageEvenement.text = PlaneteManager.Instance.currentEvent.evenementEvent.description[choix];

        vaisseau = GameObject.Find("Vaisseau");
        vaisseau.SetActive(false);

        if (PlaneteManager.Instance.currentEvent.evenementEvent.choix[choix])
        {
            boutonNON.SetActive(true);
            boutonOUI.SetActive(true);
        }

        if (PlaneteManager.Instance.currentEvent.evenementEvent.combat[choix])
        {
            boutonCombat.SetActive(true);
        }

        if (PlaneteManager.Instance.currentEvent.evenementEvent.hub[choix])
        {
            boutonHUB.SetActive(true);
        }
    }

    public void selectionOUI()
    {
        GameObject mod = Instantiate(PlaneteManager.Instance.currentEvent.evenementEvent.modulePossible[choix], new Vector3(transform.position.x,transform.position.y,0), Quaternion.identity);
        boutonNON.SetActive(false);
        boutonOUI.SetActive(false);
        vaisseau.SetActive(true);
        boutonHUB.SetActive(true);
    }

    public void RetourHub()
    {
        vaisseau.SetActive(true);
        SceneManager.LoadSceneAsync("MenuHub");
    }

    public void Combat()
    {
        vaisseau.SetActive(true);
        SceneManager.LoadSceneAsync("MenuCombat");
    }
}