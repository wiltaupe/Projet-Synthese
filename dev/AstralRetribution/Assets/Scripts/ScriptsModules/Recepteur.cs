using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recepteur : Module
{
    public override Etat Type { get; set; } = Etat.actif;
    public override bool Recept { get; set; } = true;

}
