using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabVaisseau;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            Instantiate(prefabVaisseau);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
