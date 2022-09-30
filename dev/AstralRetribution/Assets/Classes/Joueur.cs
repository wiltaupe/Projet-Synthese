using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur
{
    private Vaisseau vaisseau;

    public void AjouterVaisseau(Vaisseau vaisseau)
    {
        this.vaisseau = vaisseau;
    }

    public Vaisseau GetVaisseau()
    {
        return vaisseau;
    }


}
