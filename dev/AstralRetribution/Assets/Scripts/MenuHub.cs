using UnityEngine;
using UnityEngine.Tilemaps;

public class menuhub : MonoBehaviour
{
    public TileBase gridtile;

    GameObject grid,gridtest;
    Tilemap vaisseau,plancher,mur;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Grid");
        plancher = objs[0].GetComponent<Tilemap>();
        mur = objs[1].GetComponent<Tilemap>();

        //objs[0].transform.position = new Vector3(-398,-40,1);

        //t_plan.Scale.X = 0.75;
        //t_plan.Scale.Y = 0.75;

        //tilemap.SetTileFlags(cellPos, TileFlags.None);
        //tilemap.SetTileFlags(position, TileFlags.None);
        //plancher.SetColor(position, Color.blue);
        //gridtest = GameObject.Find("GameZone");

        //Debug.Log(gridtest);
        //gridtest.SetActive(false);


        /*grid = GameObject.Find("Vaisseau_toit");
        vaisseau = grid.GetComponent<Tilemap>();

        vaisseau.SetTile(new Vector3Int(1, 0, 0), gridtile);
        vaisseau.SetTile(new Vector3Int(2, 0, 0), gridtile);
        vaisseau.SetTile(new Vector3Int(2, 1, 0), gridtile);
        vaisseau.SetTile(new Vector3Int(2, 2, 0), gridtile);*/
    }

    // Update is called once per frame
    void Update()
    {
    }
}
