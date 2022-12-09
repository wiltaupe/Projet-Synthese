using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soigneur : MembreEquipage
{

    private void OnEnable()
    {
        MembreEquipage.OnMemberHit += MembreEquipage_OnMemberHit;
    }

    private void OnDisable()
    {
        MembreEquipage.OnMemberHit -= MembreEquipage_OnMemberHit;
    }

    private void MembreEquipage_OnMemberHit(MembreEquipage obj)
    {
        if (!action && obj.ennemi)
        {
            this.etat = MembreEquipage.EnumEquipages.ePathFindingEnnemi;
            this.cible = obj.tuile.Position;
        }

        else
        {
            this.etat = MembreEquipage.EnumEquipages.ePathFinding;
            this.cible = obj.tuile.Position;
        }
    }
}