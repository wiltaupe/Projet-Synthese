using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vestige : Module
{
    public int BuildMax { get; set; } = 500;
    [field: SerializeField] public int BuildCurrent { get; set; } = 0;
    public override Etat Type { get; set; } = Etat.passif;
}