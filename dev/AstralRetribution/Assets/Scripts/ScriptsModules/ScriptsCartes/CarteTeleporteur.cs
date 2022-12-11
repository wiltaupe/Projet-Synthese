using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteTeleporteur : Carte
{
    public override void PlayCard()
    {
        GameManager.Instance.VaisseauJoueur.GetComponent<Vaisseau>().SwitchTeleporteur();
    }

}
