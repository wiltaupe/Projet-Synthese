using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelection : MonoBehaviour
{
    public Image image;
    public Sprite[] textures;
    public GenerateurDeSalle generateurDeSalle;
    public int nbSalle;
    public Vector2 taille;
    // Start is called before the first frame update
    void Start()
    {
        GenererBackground();
        GenererVaisseau();
        generateurDeSalle = new GenerateurDeSalle(nbSalle,taille);
        
    }

    private void GenererVaisseau()
    {
    }

    private void GenererBackground()
    {
        int randomInt = UnityEngine.Random.Range(0, textures.Length);
        image.sprite = textures[randomInt];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}