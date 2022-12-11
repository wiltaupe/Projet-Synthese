using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteBouclier : Carte
{
    [field:SerializeField]public float MontantProtection {get;set;}
    public Sol Cible { get; set; }

    public override void PlayCard(Salle cible)
    {
        
    }
}
