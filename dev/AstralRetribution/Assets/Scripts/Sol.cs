using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sol : Tile
{
    private Color startcolor;
    public Module Module { get; set; }
    public Objet objet { get; set; }

    public Vector2 position { get; set; }
    void OnMouseEnter()
    {
        startcolor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.yellow;
    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = startcolor;
    }

    private void OnMouseDown()
    {
        Debug.Log(position);
    }
}
