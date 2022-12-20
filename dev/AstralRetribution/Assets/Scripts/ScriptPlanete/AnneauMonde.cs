using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnneauMonde : Planete
{
    void Start()
    {
        cercle = transform.GetChild(0).gameObject;

    }

    void Update()
    {

    }

    override public Planete EnvoyerEvent()
    {
        return this;
    }
}
