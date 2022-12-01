using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public GameObject tuiles;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    private void OnMouseOver()
    {
        tuiles.SetActive(true);
    }
    private void OnMouseExit()
    {
        tuiles.SetActive(false);
    }
}
