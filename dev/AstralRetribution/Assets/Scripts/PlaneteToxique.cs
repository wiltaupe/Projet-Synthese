using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneteToxique : Planete
{
    public EvenementToxique eventToxique;
    

    // Start is called before the first frame update
    void Start()
    {
        cercle = transform.GetChild(0).gameObject;
        monEvenement = new EvenementToxique();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class EvenementToxique : Evenement
    {
    }

    override public Evenement EnvoyerEvent()
    {
        Debug.Log("je suis toxique je joue a LOL");
        return monEvenement;
    }
}
