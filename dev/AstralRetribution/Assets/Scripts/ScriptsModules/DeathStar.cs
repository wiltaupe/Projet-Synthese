using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStar : Module
{
    public GameObject PrefabFinal;
    public override Etat Type { get; set; } = Etat.actif;

    private void Update()
    {
        if(Vaisseau != null)
        {
            if(Vaisseau.vestigeCourrant != null)
            {
                if (Vaisseau.vestigeCourrant.BuildCurrent == Vaisseau.vestigeCourrant.BuildMax)
                {
                    Prefab = PrefabFinal;
                }
            }
        }
    }
}