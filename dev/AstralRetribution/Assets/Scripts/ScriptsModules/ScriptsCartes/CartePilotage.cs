using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartePilotage : Carte
{
    public float puissanceAttaque;
    public float precision;

    public override void PlayCard(Salle cible)
    {
        if (Random.Range(0f,1f)<= precision)
        {
            cible.RecevoirDegats(puissanceAttaque);
            GameManager.Instance.LancerMissile(cible);
        }
        else
        {
            GameManager.Instance.MissParticleSpawn(cible);
        }
    }

}
