using UnityEngine;

public class MembreEquipage : MonoBehaviour
{
    public Sol tuile { get; set; }
    public bool ennemi { get; set; }
    
    public Vector2 cible;

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
}