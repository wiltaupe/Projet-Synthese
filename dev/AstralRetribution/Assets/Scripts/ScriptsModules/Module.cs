using UnityEngine;

public class Module : MonoBehaviour
{
    private Vector3 dragOffset;
    private Camera cam;
    private Vector3 lastPos;
    private Sol currentTile;
    private bool redo = false;
    private bool aBouger = false;
    private bool draggable = true;
    public GameObject Prefab;
    public int nbCartes;
    public virtual Etat Type { get; set; }

    private void Awake()
    {
        cam = Camera.main;
    }

    public enum Etat
    {
        actif,
        passif
    }

    private void OnMouseDown()
    {
        if (draggable)
        {
            float ajuster = (float)10 / (float)ShipManager.Taille;

            dragOffset = transform.position - GetMousePos();
            lastPos = GetMousePos();

            if (redo == false || aBouger == false)
            {
                this.transform.localScale = new Vector3(ajuster, ajuster, 0);
                redo = true;
            }

            GetComponent<SpriteRenderer>().sortingOrder += 2;
        }
        

    }

    private void OnMouseDrag()
    {
        if (draggable)
        {
            transform.position = GetMousePos() + dragOffset;
        }
        
    }

    Vector3 GetMousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    private void OnMouseUp()
    {
        if (draggable)
        {
            GetComponent<SpriteRenderer>().sortingOrder += 2;
            Collider2D col = Physics2D.OverlapPoint(GetMousePos(), LayerMask.GetMask("Sol"));
            if (col == null)
            {
                if (currentTile == null)
                {
                    transform.position = lastPos;
                    this.transform.localScale = new Vector3(1, 1, 0);
                }
                else transform.position = currentTile.transform.position;
                return;
            }

            Sol sol = col.gameObject.GetComponent<Sol>();

            if (sol.Module == null && sol.MembreEquipage == null)
            {
                if (currentTile != null)
                {
                    currentTile.Module = null;
                }

                aBouger = true;

                sol.Module = this;
                transform.position = sol.transform.position;
                transform.SetParent(sol.transform);

                lastPos = sol.transform.position;
                sol.Traversable = false;
                sol.Vaisseau.AddModule(this);
                draggable = false;
            }
            else
            {
                if (currentTile == null)
                {
                    this.transform.localScale = new Vector3(1, 1, 0);
                    transform.position = lastPos;
                }
                else
                {
                    this.transform.localScale = new Vector3(1, 1, 0);
                    transform.position = currentTile.gameObject.transform.position;
                }
            }
        }
        

    }
}