using System;
using UnityEngine;
using UnityEngine.Events;

public class MembreEquipage : MonoBehaviour
{
    public static event Action­<MembreEquipage> OnMemberHit;
    public Sol tuile { get; set; }
    [field: SerializeField] public float vitesse { get; set; } = 10f;
    public bool ennemi { get; set; }
    public Vector2 cible;
    public bool action;
    public float MaxVie { get; set; } = 30;
    [field: SerializeField] public float CurrentVie { get; set; }
    [field: SerializeField] public GameObject MortPrefab { get; private set; }

    public EnumEquipages etat;
    public bool cloneTeleporter;
    public Vaisseau vaisseau;

    private void Start()
    {
        CurrentVie = MaxVie;
        etat = EnumEquipages.ePassif;
    }

    public enum EnumEquipages
    {
        eInactif = 1,
        ePassif = 2,
        ePathFinding = 3,
        ePathFindingEnnemi = 4,
        eAction = 5
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
            OnMemberHit?.Invoke(this);
        }
    }

    public virtual void MembreMort()
    {
        Instantiate(MortPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public virtual void ActionEquipage()
    {
    }
}