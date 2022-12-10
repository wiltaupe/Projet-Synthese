using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recepteur : Module
{
    public override Etat Type { get; set; } = Etat.passif;
    public override bool recepteur { get; set; } = true;

}
