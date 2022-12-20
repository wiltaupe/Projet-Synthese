using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedster : Module
{
    public override Etat Type { get; set; } = Etat.passif;
    
    void Update()
    {
        if(Type == Etat.passif && salleModule != null)
        {
            foreach (Sol sol in salleModule.Tuiles)
            {
                if (sol.MembreEquipage != null)
                {
                    sol.MembreEquipage.GetComponent<MembreEquipage>().vitesse = 20f;
                }
            }
        }

        if (CurrentVie <= 0 && Type == Etat.inactif)
        {
            MiseAJourSpeed();
        }
    }

    private void MiseAJourSpeed()
    {
        if (Vaisseau != null)
        {
            foreach (GameObject m in Vaisseau.MembresEquipage)
            {
                m.GetComponent<MembreEquipage>().vitesse = 10f;
            }
        }

        if (vaisseauEnnemi != null)
        {
            foreach (GameObject m in vaisseauEnnemi.MembresEquipage)
            {
                m.GetComponent<MembreEquipage>().vitesse = 10f;
            }
        }
    }
}
