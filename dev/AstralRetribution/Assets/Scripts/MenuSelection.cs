using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelection : MonoBehaviour
{
    public Image image;
    public Sprite[] textures;
    // Start is called before the first frame update
    void Start()
    {
        GenererBackground();
        GenererVaisseau();
    }

    void GenererVaisseau()
    {
        GameObject gameObject = GameObject.Find("GenerateurSalle");
        GenerateurSalle gs = gameObject.GetComponent<GenerateurSalle>();
        Vaisseau vaisseau = gs.GenererVaisseau(20,3);
        Debug.Log(vaisseau);
    }

    void AfficherVaisseau()
    {

    }

    private void GenererBackground()
    {
        int randomInt = UnityEngine.Random.Range(0, textures.Length);
        image.sprite = textures[randomInt];
    }
}
