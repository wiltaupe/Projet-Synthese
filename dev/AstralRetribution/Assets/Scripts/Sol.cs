using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sol : Tile
{
    private Color startcolor;
    public Module Module { get; set; }
    public Objet objet { get; set; }
    void OnMouseEnter()
    {
        startcolor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.yellow;
    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = startcolor;
    }
}
