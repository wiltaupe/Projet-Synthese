using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteClone : Carte
{
    public override void PlayCard()
    {
        StartCoroutine(GameManager.Instance.VaisseauJoueur.GetComponent<Vaisseau>().EnvoyerClone());
    }
}
