using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // source : https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Generateur");

        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
