using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soigneur : MembreEquipage
{
    override public void actionEquipage(MembreEquipage m)
    {
        
        etat = MembreEquipage.EnumEquipages.ePathFinding;
        cible = m.tuile.Position;
    }
}