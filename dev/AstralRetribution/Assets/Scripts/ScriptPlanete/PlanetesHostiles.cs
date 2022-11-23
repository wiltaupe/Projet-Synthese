using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetesHostiles : Planete
{

    // Start is called before the first frame update
    void Start()
    {
        cercle = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }


    override public Planete EnvoyerEvent()
    {
        Debug.Log("je suis comme les leafs en série, je suis Hostiles et je perd");
        return this;
    }
}
