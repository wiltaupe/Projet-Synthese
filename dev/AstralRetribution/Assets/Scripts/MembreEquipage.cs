using System;
using UnityEngine;
using UnityEngine.Events;

public class MembreEquipage : MonoBehaviour
{
    public UnityEvent­<MembreEquipage> bless;
    public Sol tuile { get; set; }
    public bool ennemi { get; set; }
    
    public Vector2 cible;
    public bool action;

    public float MaxVie { get; set; } = 30;
    public float CurrentVie { get; set; }
    public EnumEquipages etat;

    private void Start()
    {
        CurrentVie = MaxVie;
        etat = EnumEquipages.ePassif;
        Debug.Log(etat);
    }

    public enum EnumEquipages
    {
        eInactif = 1,
        ePassif = 2,
        eDeplacement = 3,
        ePathFinding = 4,
        eDeplacementPathfindin = 5
    };

    

    public virtual void actionEquipage()
    {

    }

    public virtual void actionEquipage(MembreEquipage m)
    {

    }

    public virtual void actionEquipage(Module m)
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