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


    internal List<Salle> AfficherSalles(List<RectInt> rectSalles,int taille)
    {
        List<Salle> salles = new();
        foreach (RectInt rectInt in rectSalles)
        {
            Dictionary<Vector2, Sol> tiles = new();
            for (int i = rectInt.xMin; i <= rectInt.xMax; i++)
            {
                for (int j = rectInt.yMin; j <= rectInt.yMax; j++)
                {
                    
                    if (i == rectInt.xMin || i == rectInt.xMax || j == rectInt.yMin || j == rectInt.yMax)
                    {
                        
                        var obj = Instantiate(mur, new Vector3(i * (tileSize * (1 -(Screen.width / 1920) + (Screen.width / 1920))), j * (tileSize * (( 1 - Screen.height / 1080) + Screen.height / 1080))) + transform.position, Quaternion.identity);
                        obj.transform.SetParent(GameObject.Find("Tuiles").transform);


                    }
                    else
                    {
                        Sol obj = Instantiate(sol, new Vector3(i * (tileSize * (1 - (Screen.width / 1920) + (Screen.width / 1920))), j * (tileSize * ((1 - Screen.height / 1080) + Screen.height / 1080))) + transform.position, Quaternion.identity);
                        obj.transform.SetParent(GameObject.Find("Tuiles").transform);
                        obj.position = new Vector2(i, j);
                        tiles[new Vector2(i, j)] = obj;
                        obj.name = $"Sol x:{i} y:{j}";
                    }

                    if (rectInt.xMin != 0)
                    {

                        var obj = Instantiate(porte, new Vector3(rectInt.xMin * (tileSize * (1 - (Screen.width / 1920) + (Screen.width / 1920))), (int)rectInt.center.y * (tileSize * ((1 - Screen.height / 1080) + Screen.height / 1080))) + transform.position, Quaternion.identity);
                        obj.transform.SetParent(GameObject.Find("Tuiles").transform);
                        obj.transform.Rotate(0, 0, 90, Space.Self);

                    }
                    
                    if (rectInt.xMax != taille)
                    {
                        var obj = Instantiate(porte, new Vector3(rectInt.xMax * (tileSize * (1 - (Screen.width / 1920) + (Screen.width / 1920))), (int)rectInt.center.y * (tileSize * ((1 - Screen.height / 1080) + Screen.height / 1080))) + transform.position, Quaternion.identity);
                        obj.transform.SetParent(GameObject.Find("Tuiles").transform);
                        obj.transform.Rotate(0, 0, 90, Space.Self);
                    }

                    if (rectInt.yMin != 0)
                    {
                        var obj = Instantiate(porte, new Vector3((int)rectInt.center.x * (tileSize * (1 - (Screen.width / 1920) + (Screen.width / 1920))), rectInt.yMin * (tileSize * ((1 - Screen.height / 1080) + Screen.height / 1080))) + transform.position, Quaternion.identity);
                        obj.transform.SetParent(GameObject.Find("Tuiles").transform);
                    }

                    if (rectInt.yMax != taille)
                    {
                        var obj = Instantiate(porte, new Vector3((int)rectInt.center.x * (tileSize * (1 - (Screen.width / 1920) + (Screen.width / 1920))), rectInt.yMax * (tileSize * ((1 - Screen.height / 1080) + Screen.height / 1080))) + transform.position, Quaternion.identity);
                        obj.transform.SetParent(GameObject.Find("Tuiles").transform);
                    }

                    
                }
            }
            
            Salle salle = new(rectInt.width, rectInt.height, tiles);

            salles.Add(salle);
        }

        return salles;
    }
}
