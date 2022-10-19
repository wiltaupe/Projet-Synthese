using UnityEngine;
using UnityEngine.Tilemaps;

public class Affichage : MonoBehaviour
{
    /*public void AfficherVaisseau(Vaisseau vaisseau, Tilemap tilemap, TileBase[] tileBase)
    {
        tilemap.ClearAllTiles();

        foreach (RectInt rectInt in vaisseau.salles)
        {
            foreach (Vector3Int vector2 in rectInt.allPositionsWithin)
            {
                tilemap.SetTile(vector2, tileBase[0]);
            }
            for (int i = rectInt.x; i <= rectInt.xMax; i++)
            {
                tilemap.SetTile(new Vector3Int(i, rectInt.y), tileBase[1]);
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


    }*/

    internal void AfficherMurs(Vaisseau vaisseau, Tilemap tilemap, TileBase tileBase)
    {
        tilemap.ClearAllTiles();
        foreach (RectInt rectInt in vaisseau.salles)
        {
            for (int i = rectInt.x; i <= rectInt.xMax; i++)
            {
                tilemap.SetTile(new Vector3Int(i, rectInt.y), tileBase);
            }
            for (int i = rectInt.x; i <= rectInt.xMax; i++)
            {
                tilemap.SetTile(new Vector3Int(i, rectInt.yMax), tileBase);
            }
            for (int i = rectInt.yMin; i <= rectInt.yMax; i++)
            {
                tilemap.SetTile(new Vector3Int(rectInt.x, i), tileBase);
            }
            for (int i = rectInt.yMin; i <= rectInt.yMax; i++)
            {
                tilemap.SetTile(new Vector3Int(rectInt.xMax, i), tileBase);
            }
        }
    }


    internal void AfficherSol(Vaisseau vaisseau, Tilemap tilemap, TileBase tileBase)
    {
        tilemap.ClearAllTiles();
        foreach (RectInt rectInt in vaisseau.salles)
        {
            for (int i = rectInt.x; i <= rectInt.xMax; i++)
            {
                for (int j = rectInt.y; j < rectInt.yMax; j++)
                {
                    tilemap.SetTile(new Vector3Int(i,j), tileBase);
                }
            }
        }
    }
}
