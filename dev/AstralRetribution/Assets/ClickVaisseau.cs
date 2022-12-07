using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickVaisseau : MonoBehaviour
{
    public GameObject tuiles;
    private void OnMouseDown()
    {
        tuiles.SetActive(true);
    }
}
