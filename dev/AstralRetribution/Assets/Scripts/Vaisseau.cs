using System.Collections.Generic;
using UnityEngine;

public class Vaisseau
{
    private List<RectInt> salles;

    public Vaisseau(List<RectInt> salles)
    {
        this.salles = salles;
    }
}