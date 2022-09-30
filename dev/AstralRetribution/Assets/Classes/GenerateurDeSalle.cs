using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateurDeSalle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public List<Vector2> GenererSalles()
    {
        List<Vector2> liste = new List<Vector2>();
        for (int i = 0; i < 10; i++)
        {
            liste.Add(new Vector2(i, i));
        }
        return liste;
    }
}
