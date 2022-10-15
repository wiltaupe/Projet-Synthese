using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaisseau : MonoBehaviour
{
    public List<RectInt> salles { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = GameObject.Find("GenerateurSalle");
        GenerateurSalle generateurSalle = gameObject.GetComponent<GenerateurSalle>();
        salles = generateurSalle.GenererSalles(20, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
