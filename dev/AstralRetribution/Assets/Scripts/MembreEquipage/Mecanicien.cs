using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanicien : MembreEquipage
{
    public GameObject particuleEffect;
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
    public override void ActionEquipage()
    {
        Instantiate(particuleEffect, transform.position, Quaternion.identity);
    }

}
