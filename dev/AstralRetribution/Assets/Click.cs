using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    private GameObject tuiles;
    // Start is called before the first frame update
    private void Start()
    {
        Button btn = GetComponent<Button>();
        tuiles = GameObject.Find("Tuiles");
        btn.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        Debug.Log(tuiles);
        if (tuiles.activeInHierarchy)
        {
            tuiles.SetActive(false);
        }
        else
        {
            tuiles.SetActive(true);
        }
    }
}
