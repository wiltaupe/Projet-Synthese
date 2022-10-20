using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MenuHub : MonoBehaviour
{
    public TileBase gridtile;
    public Transform positionVaisseau;
    public Image background;

    GameObject grid,vaisseau;
    GridManager management;

    // Start is called before the first frame update
    void Start()
    {
        vaisseau = GameObject.Find("Vaisseau");
        background.sprite = MainManager.Instance.Background;
        management = MainManager.Instance.GridManager;

        vaisseau.transform.localScale = new Vector3(0.41f, 0.41f, 0);
        vaisseau.transform.position = positionVaisseau.position;
        

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
