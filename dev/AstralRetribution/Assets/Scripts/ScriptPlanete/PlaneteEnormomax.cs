using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneteEnormomax : Planete
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
