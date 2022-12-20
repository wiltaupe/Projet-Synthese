using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telescope : Module
{
    public override Etat Type { get; set; } = Etat.passif;
    private bool DejaFait = false;

    void Update()
    {
        if (Type == Etat.passif && !DejaFait)
        {
            if (Vaisseau != null)
            {
                Vaisseau.esquive  = Vaisseau.esquive * 2;
            }

            if (vaisseauEnnemi != null)
            {
                vaisseauEnnemi.esquive = vaisseauEnnemi.esquive * 2;
            }
        }

        if (CurrentVie <= 0 && Type == Etat.inactif)
        {
            MiseAJourPresicion();
        }
    }

    private void MiseAJourPresicion()
    {

    }
}
