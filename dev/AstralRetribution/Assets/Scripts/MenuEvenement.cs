using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuEvenement : MonoBehaviour
{
    public Image background;
    private bool vaisseauImportant = false;
    GameObject vaisseau;

    // Start is called before the first frame update
    void Start()
    {
        background.sprite = MainManager.Instance.Background;

        if (!vaisseauImportant)
        {
            vaisseau = GameObject.Find("Vaisseau");
            vaisseau.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
