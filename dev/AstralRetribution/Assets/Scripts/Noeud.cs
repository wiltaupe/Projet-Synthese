using System.Collections.Generic;
using UnityEngine;

internal class Noeud
{
    public List<Vector2> points { get; set; }
    public Noeud gauche{ get; set; }
    public Noeud droite{ get; set; }

    public Noeud(List<Vector2> vector2s)
    {
        points = vector2s;
    }

}