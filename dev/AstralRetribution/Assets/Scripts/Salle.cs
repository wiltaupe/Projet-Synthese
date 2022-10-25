using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salle
{
    public int Width { get; set; }
    public int Height { get; set; }
    public List<Sol> Tuiles { get; set; }

    public Salle(int width, int height, List<Sol> tuiles)
    {
        Width = width;
        Height = height;
        Tuiles = tuiles;
    }
    
}
