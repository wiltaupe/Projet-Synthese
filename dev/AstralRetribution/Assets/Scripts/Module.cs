using UnityEngine;

public class Module : MonoBehaviour
{
    private Vector3 dragOffset;
    private Camera cam;
    private Vector3 lastPos;
    private Sol currentTile;
    private bool redo = false;
    private bool aBouger = false;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void OnMouseDown()
    {

        float ajuster = (float)10 / (float)ShipManager.taille;

        dragOffset = transform.position - GetMousePos();
        lastPos = GetMousePos();

        if (redo == false || aBouger == false)
        {
            this.transform.localScale = new Vector3(ajuster, ajuster, 0);
            redo = true;
        }

        GetComponent<SpriteRenderer>().sortingOrder += 1;

    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePos() + dragOffset;
    }

    Vector3 GetMousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sortingOrder -= 1;
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

        if (col.gameObject.GetComponent<Sol>().Module == null && col.GetComponent<Sol>().MembreEquipage == null)
        {
            if (currentTile != null)
            {
                currentTile.Module = null;
            }

            aBouger = true;

            col.gameObject.GetComponent<Sol>().Module = this;
            currentTile = col.gameObject.GetComponent<Sol>();
            transform.position = currentTile.transform.position;
            transform.SetParent(currentTile.transform);
            lastPos = currentTile.transform.position;
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