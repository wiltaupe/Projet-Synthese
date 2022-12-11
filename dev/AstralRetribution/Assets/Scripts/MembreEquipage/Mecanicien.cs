using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanicien : MembreEquipage
{

    private void OnEnable()
    {
        Module.OnModuleHit += Module_OnModuleHit;
    }

    private void OnDisable()
    {
        Module.OnModuleHit -= Module_OnModuleHit;
    }

    private void Module_OnModuleHit(Module obj)
    {
        if (obj.Ennemi)
        {
            this.etat = MembreEquipage.EnumEquipages.ePathFindingEnnemi;
            this.cible = obj.currentTile.Position;
        }
        else
        {
            this.etat = MembreEquipage.EnumEquipages.ePathFinding;
            this.cible = obj.currentTile.Position;
        }

    }
}
