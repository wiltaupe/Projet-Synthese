using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneteNeutre : Planete
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
        Debug.Log("Leve sa main : je n'ai pas d'opinion je suis Neutre. Merci Co.");
        return this;
    }
}
