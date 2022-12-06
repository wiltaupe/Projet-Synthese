using System;
using UnityEngine;
using UnityEngine.Events;

public class MembreEquipage : MonoBehaviour
{
    public membreBlesser­ bless;
    public Sol tuile { get; set; }
    public bool ennemi { get; set; }
    
    public Vector2 cible;

    public float MaxVie { get; set; } = 30;
    public float CurrentVie { get; set; }

    private void Start()
    {
        CurrentVie = MaxVie;
    }

    public enum EnumEquipages
    {
        eInactif = 1,
        ePassif = 2,
        eDeplacement = 3,
        ePathFinding = 4,
        eDeplacementPathfindin = 5
    };

    public EnumEquipages etat;

    public virtual void actionEquipage()
    {

    }

    public virtual void actionEquipage(MembreEquipage m)
    {

    }

    internal void RecevoirDegats(float puissance)
    {
        CurrentVie -= puissance;
        if (CurrentVie <= 0)
        {
            MembreMort();
        }

        else
        {
            bless?.Invoke(this);
        }
    }

    private void MembreMort()
    {
        Destroy(this.gameObject);
    }
}

[System.Serializable]
public class membreBlesser­: UnityEvent­<MembreEquipage>
{

}