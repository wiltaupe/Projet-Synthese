using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyVaisseau : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Vaisseau");

        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
