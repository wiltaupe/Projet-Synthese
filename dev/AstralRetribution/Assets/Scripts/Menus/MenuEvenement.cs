using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuEvenement : MonoBehaviour
{
    public Image background;
    private bool vaisseauImportant = false;
    GameObject vaisseau;
    public TextMeshProUGUI messageEvenement;
    public GameObject boutonOUI, boutonNON, boutonCombat, boutonHUB;

    // Start is called before the first frame update
    void Start()
    {

        int choix = Random.Range(0, PlaneteManager.Instance.currentEvent.evenementEvent.background.Length);
        int choixDescription = Random.Range(0, PlaneteManager.Instance.currentEvent.evenementEvent.description.Length);
        background.sprite = PlaneteManager.Instance.currentEvent.evenementEvent.background[choix];

        messageEvenement.text = PlaneteManager.Instance.currentEvent.evenementEvent.description[choixDescription];

        if (!vaisseauImportant)
        {
            vaisseau = GameObject.Find("Vaisseau");
            vaisseau.SetActive(false);
        }

        if (PlaneteManager.Instance.currentEvent.evenementEvent.choix)
        {
            boutonNON.SetActive(true);
            boutonOUI.SetActive(true);
        }

        if (PlaneteManager.Instance.currentEvent.evenementEvent.combat)
        {
            boutonCombat.SetActive(true);
        }

        if (PlaneteManager.Instance.currentEvent.evenementEvent.hub[0])
        {
            boutonHUB.SetActive(true);
        }



    }

    // Update is called once per frame
    void Update()
    {

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