using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Tile mur;
    [SerializeField] private Sol sol;
    [SerializeField] private Porte porte;
    [SerializeField] private int tileSize = 32;


    internal List<Salle> AfficherSalles(List<RectInt> rectSalles,int taille,Vaisseau vaisseau)
    {
        List<Salle> salles = new();
        foreach (RectInt rectInt in rectSalles)
        {
            List<Sol> tiles = new();
            for (int i = rectInt.xMin; i <= rectInt.xMax; i++)
            {
                for (int j = rectInt.yMin; j <= rectInt.yMax; j++)
                {
                    
                    if (i == rectInt.xMin || i == rectInt.xMax || j == rectInt.yMin || j == rectInt.yMax)
                    {
                        
                        var obj = Instantiate(mur, new Vector3(i * (tileSize * Screen.width / 1920), j  * ((tileSize * Screen.height) / 1080)) + vaisseau.transform.position, Quaternion.identity);
                        obj.transform.SetParent(vaisseau.transform.Find("Tuiles"));


                    }
                    else
                    {
                        Sol obj = Instantiate(sol, new Vector3(i * ((tileSize * Screen.width) / 1920), j  * ((tileSize * Screen.height) / 1080)) + vaisseau.transform.position, Quaternion.identity);
                        obj.transform.SetParent(vaisseau.transform.Find("Tuiles"));
                        obj.position = new Vector2(i, j);
                        tiles.Add(obj);
                        obj.name = $"Sol x:{i} y:{j}";
                    }

                    if (rectInt.xMin != 0)
                    {

                        var obj = Instantiate(porte, new Vector3(rectInt.xMin * ((tileSize * Screen.width) / 1920), (int)rectInt.center.y * ((tileSize * Screen.height) / 1080)) + vaisseau.transform.position, Quaternion.identity);
                        obj.transform.SetParent(vaisseau.transform.Find("Tuiles"));
                        obj.transform.Rotate(0, 0, 90, Space.Self);

                    }
                    
                    if (rectInt.xMax != taille)
                    {
                        var obj = Instantiate(porte, new Vector3(rectInt.xMax  * ((tileSize * Screen.width) / 1920), (int)rectInt.center.y * ((tileSize * Screen.height) / 1080)) + vaisseau.transform.position, Quaternion.identity);
                        obj.transform.SetParent(vaisseau.transform.Find("Tuiles"));
                        obj.transform.Rotate(0, 0, 90, Space.Self);
                    }

                    if (rectInt.yMin != 0)
                    {
                        var obj = Instantiate(porte, new Vector3((int)rectInt.center.x * ((tileSize * Screen.width) / 1920), rectInt.yMin * ((tileSize * Screen.height) / 1080)) + vaisseau.transform.position, Quaternion.identity);
                        obj.transform.SetParent(vaisseau.transform.Find("Tuiles"));
                    }

                    if (rectInt.yMax != taille)
                    {
                        var obj = Instantiate(porte, new Vector3((int)rectInt.center.x * ((tileSize * Screen.width) / 1920), rectInt.yMax * ((tileSize * Screen.height) / 1080)) + vaisseau.transform.position, Quaternion.identity);
                        obj.transform.SetParent(vaisseau.transform.Find("Tuiles"));
                    }

                    
                }
            }
            
            Salle salle = new(rectInt.width, rectInt.height, tiles);
            Debug.Log(salle.Tuiles.Count);

            salles.Add(salle);
        }

        return salles;
    }
}
