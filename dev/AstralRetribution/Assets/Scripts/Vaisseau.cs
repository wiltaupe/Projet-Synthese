using System.Collections.Generic;
using UnityEngine;

public class Vaisseau
{
    public List<RectInt> Salles { get; set; }

    public Vaisseau(List<RectInt> salles)
    {
        Salles = salles;
    }
}