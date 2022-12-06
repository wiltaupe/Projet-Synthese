using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanicien : MembreEquipage
{
    private Module moduleCible;

    override public void actionEquipage()
    {
        etat = MembreEquipage.EnumEquipages.ePathFinding;
        cible = moduleCible.currentTile.Position;
    }
}
