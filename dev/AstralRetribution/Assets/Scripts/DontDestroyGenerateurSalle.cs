using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyGenerateurSalle : MonoBehaviour
{
    // source : https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GenerateurSalle");

        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
