using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarteEsquive : Carte
{
    public float pourcentageEsquive = 0.5f;

    public virtual void PlayCard()
    {
        GameManager.Instance.VaisseauJoueur.GetComponent<Vaisseau>().AjoutEsquive(pourcentageEsquive);
    }

}
