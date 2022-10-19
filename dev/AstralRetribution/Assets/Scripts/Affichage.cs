using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Affichage : MonoBehaviour
{
    public void AfficherVaisseau(Vaisseau vaisseau, Tilemap tilemap, TileBase [] tileBase)
    {
        tilemap.ClearAllTiles();

        foreach(RectInt rectInt in vaisseau.salles)
        {
            foreach(Vector3Int vector2 in rectInt.allPositionsWithin)
            {
                tilemap.SetTile(vector2, tileBase[0]);
            }
            for (int i = rectInt.x; i <= rectInt.xMax; i++)
            {
                tilemap.SetTile(new Vector3Int(i,rectInt.y), tileBase[1]);
            }
            for (int i = rectInt.x; i <= rectInt.xMax; i++)
            {
                tilemap.SetTile(new Vector3Int(i, rectInt.yMax), tileBase[1]);
            }
            for (int i = rectInt.yMin; i <= rectInt.yMax; i++)
            {
                tilemap.SetTile(new Vector3Int(rectInt.x, i), tileBase[1]);
            }
            for (int i = rectInt.yMin; i <= rectInt.yMax; i++)
            {
                tilemap.SetTile(new Vector3Int(rectInt.xMax, i), tileBase[1]);
            }
        }


    }
}
