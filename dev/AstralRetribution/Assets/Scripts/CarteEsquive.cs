using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarteEsquive : Carte
{
    public float pourcentageEsquive = 0.25f;

    public virtual void PlayCard()
    {
        Debug.Log("salut");
        //GameManager.Instance.VaisseauJoueur.GetComponent<Vaisseau>().AjoutEsquive(pourcentageEsquive);
    }

}
