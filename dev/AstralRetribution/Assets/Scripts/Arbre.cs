using System.Collections.Generic;
using UnityEngine;

internal class Arbre
{
    public Noeud racine{ get; set; }

public Arbre (List<Vector2> list)
    {
        racine = new Noeud(list);
    }
}