using System;
using System.Collections;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInitial : MonoBehaviour
{
    public TextMeshProUGUI nom;
    public TextMeshProUGUI age;
    public GameObject Texte;
    public GameObject affichage;
    public GameObject identite;
    public void DemarrerPartie()
    {
        SceneManager.LoadSceneAsync("MenuSelection");
    }
    public void QuitterPartie()
    {
        Application.Quit();
    }
    public void Options()
    {
        SceneManager.LoadSceneAsync("MenuOption");
    }

    public void Confirmation()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("nom", nom.text);
        PlayerPrefs.SetString("age", age.text);
        if (Regex.IsMatch(nom.text, "William Caron", RegexOptions.IgnoreCase) || Regex.IsMatch(nom.text, "David Demers", RegexOptions.IgnoreCase))
        {
            StartCoroutine(Transition("Hey tu as le meme nom que mon boss!"));
        }
        else
        {
            StartCoroutine(Transition("Salut le nouveau, c'est toi le boss aujourd'hui?"));
        }
    }

    private IEnumerator Transition(string texte)
    {
        Texte.SetActive(true);
        Texte.GetComponent<TextMeshProUGUI>().text = texte;
        yield return new WaitForSeconds(2f);
        affichage.SetActive(false);
        identite.GetComponent<TextMeshProUGUI>().text = $"salut capitaine {PlayerPrefs.GetString("nom")}, tu as encore {PlayerPrefs.GetString("age")} ans n'est-ce pas ? ";


    }

    private void Start()
    {
        //PlayerPrefs.DeleteAll();

        if (PlayerPrefs.HasKey("nom") && PlayerPrefs.HasKey("age"))
        {
            identite.GetComponent<TextMeshProUGUI>().text = $"salut capitaine {PlayerPrefs.GetString("nom")}, tu as encore {PlayerPrefs.GetString("age")} ans n'est-ce pas ? ";
        }
        else
        {
            affichage.SetActive(true);
        }

        

    } 
}
