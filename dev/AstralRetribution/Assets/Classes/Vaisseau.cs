using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaisseau : MonoBehaviour
{
    private List<Vector2> salles;
    private GenerateurDeSalle generateurDeSalle;

    


    // Start is called before the first frame update
    void Start()
    {
        generateurDeSalle = gameObject.AddComponent<GenerateurDeSalle>();
        salles = generateurDeSalle.GenererSalles();
    }

    public List<Vector2> VoirSalles()
    {
        return salles;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
