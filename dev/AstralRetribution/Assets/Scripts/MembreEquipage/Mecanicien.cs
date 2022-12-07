using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanicien : MembreEquipage
{
    override public void actionEquipage(Module m)
    {
        Debug.Log("Reparage");
        
        if(!this.action)
        {
            this.etat = MembreEquipage.EnumEquipages.ePathFinding;
            this.cible = m.currentTile.Position;
        }

    }
}
