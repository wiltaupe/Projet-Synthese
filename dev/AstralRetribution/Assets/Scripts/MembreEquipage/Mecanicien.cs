using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanicien : MembreEquipage
{
    override public void actionEquipage(Module m)
    {
        Debug.Log("Reparage");
        if(!action)
        {
            etat = MembreEquipage.EnumEquipages.ePathFinding;
            cible = m.currentTile.Position;
        }

    }
}
