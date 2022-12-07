using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soigneur : MembreEquipage
{
    override public void actionEquipage(MembreEquipage m)
    {
        if(!action)
        {
            Debug.Log("soigneur");
            this.etat = MembreEquipage.EnumEquipages.ePathFinding;
            this.cible = m.tuile.Position;
        }
    }
}