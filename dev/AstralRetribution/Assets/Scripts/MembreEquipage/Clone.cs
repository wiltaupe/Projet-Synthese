using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MembreEquipage
{
    public Cloneur cloneur;
    public override void MembreMort()
    {
        cloneur.compteurClone = cloneur.compteurClone - 1;
        Destroy(this.gameObject);
    }

    public void ActionEquipage()
    {

        if (ennemi)
        {
            Vaisseau vaisseau = GameObject.Find("Vaisseau").GetComponent<Vaisseau>();
            this.cible = vaisseau.GetRandomModule().currentTile.Position;
            this.ennemi = false;
            this.etat = MembreEquipage.EnumEquipages.ePathFinding;
        }

        else
        {
            Vaisseau vaisseauEnnemi = GameObject.Find("VaisseauEnnemi").GetComponent<Vaisseau>();
            this.cible = vaisseauEnnemi.GetRandomModule().currentTile.Position;
            this.ennemi = true;
            this.etat = MembreEquipage.EnumEquipages.ePathFindingEnnemi;
        }
    }
}
