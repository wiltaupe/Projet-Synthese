using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteVestige : Carte
{
    public GameObject vestige;
    public bool placer { get; set; } = false;
    public override void PlayCard()
    {
        if(!placer)
        {
            GameManager.Instance.VaisseauJoueur.GetComponent<Vaisseau>().PlacerVestige(vestige);
            placer = true;
        }
        else
        {
            GameManager.Instance.VaisseauJoueur.GetComponent<Vaisseau>().vestigeCourrant.BuildCurrent = 0;
        }
    }
}
