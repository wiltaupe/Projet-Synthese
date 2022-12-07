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
            etat = MembreEquipage.EnumEquipages.ePathFinding;
            cible = m.tuile.Position;
        }
    }
}