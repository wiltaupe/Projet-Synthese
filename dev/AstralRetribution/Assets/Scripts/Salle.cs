using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salle
{
    private int Width { get; set; }
    private int Height { get; set; }
    private Dictionary<Vector2, Sol> Tuiles { get; set; }

    public Salle(int width, int height, Dictionary<Vector2,Sol> tuiles)
    {
        Width = width;
        Height = height;
        Tuiles = tuiles;

        foreach (Sol tuile in Tuiles.Values)
        {
            tuile.Parent = this;  
        }
    }
    
}
