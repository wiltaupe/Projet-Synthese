using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MenuSelection : MonoBehaviour
{
    public Image image;
    public Sprite[] textures;
    private Vaisseau vaisseauJoueur;
    public Tilemap tilemap;
    public TileBase sol, mur;
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
        vaisseauJoueur = gs.GenererVaisseau(20,3);
        
    }

    void AfficherVaisseau()
    {
        foreach (RectInt salle in vaisseauJoueur.Salles)
        {
            
        }
    }

    private void GenererBackground()
    {
        int randomInt = UnityEngine.Random.Range(0, textures.Length);
        image.sprite = textures[randomInt];
    }
}
