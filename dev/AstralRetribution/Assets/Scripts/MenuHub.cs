using UnityEngine;
using UnityEngine.Tilemaps;

public class menuhub : MonoBehaviour
{
    public TileBase gridtile;

    GameObject grid;
    Tilemap vaisseau;

    // Start is called before the first frame update
    void Start()
    {
        grid = GameObject.Find("Vaisseau_toit");
        vaisseau = grid.GetComponent<Tilemap>();

        vaisseau.SetTile(new Vector3Int(1, 0, 0), gridtile);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
