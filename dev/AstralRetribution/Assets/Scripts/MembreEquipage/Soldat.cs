using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldat : MembreEquipage
{
    private Salle salleCible;

    override public void actionEquipage()
    {
        etat = MembreEquipage.EnumEquipages.ePathFinding;
        cible = salleCible.GetMiddleSol().Position;
    }
}
