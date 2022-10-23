using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Tile mur;
    [SerializeField] Sol sol;

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
                        
                        var obj = Instantiate(mur, new Vector3(i * 32, j * 32) + transform.position, Quaternion.identity);
                        obj.transform.parent = transform.parent;


                    }
                    else
                    {
                        Sol obj = Instantiate(sol, new Vector3(i * 32, j * 32) + transform.position, Quaternion.identity);
                        obj.transform.parent = transform.parent;
                        tiles[new Vector2(i, j)] = obj;
                    }

                    if (rectInt.xMin != 0)
                    {

                        var obj = Instantiate(sol, new Vector3(rectInt.xMin * 32, (int)rectInt.center.y * 32) + transform.position, Quaternion.identity);
                        obj.transform.parent = transform.parent;

                    }
                    
                    if (rectInt.xMax != taille)
                    {
                        var obj = Instantiate(sol, new Vector3(rectInt.xMax * 32, (int)rectInt.center.y * 32) + transform.position, Quaternion.identity);
                        obj.transform.parent = transform.parent;
                    }

                    if (rectInt.yMin != 0)
                    {
                        var obj = Instantiate(sol, new Vector3((int)rectInt.center.x * 32, rectInt.yMin * 32) + transform.position, Quaternion.identity);
                        obj.transform.parent = transform.parent;
                    }

                    if (rectInt.yMax != taille)
                    {
                        var obj = Instantiate(sol, new Vector3((int)rectInt.center.x * 32, rectInt.yMax * 32) + transform.position, Quaternion.identity);
                        obj.transform.parent = transform.parent;
                    }

                    
                }
            }
            
            Salle salle = new(rectInt.width, rectInt.height, tiles);

            salles.Add(salle);
        }

        return salles;
    }
}
