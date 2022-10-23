using UnityEngine;

public class Module : MonoBehaviour
{
    private Vector3 dragOffset;
    private Camera cam;
    private Vector3 lastPos;
    private Sol currentTile;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void OnMouseDown()
    {
        dragOffset = transform.position - GetMousePos();
        lastPos = GetMousePos();

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
        Collider2D col = Physics2D.OverlapPoint(GetMousePos(), LayerMask.GetMask("Sol"));
        if (col == null)
        {
            if (currentTile == null)
            {
                transform.position = lastPos;
            }
            else transform.position = currentTile.transform.position;
            return;
        }

        if (col.gameObject.GetComponent<Sol>().Module == null)
        {
            if (currentTile != null)
            {
                currentTile.Module = null;
            }
            
            col.gameObject.GetComponent<Sol>().Module = this;
            currentTile = col.gameObject.GetComponent<Sol>();
            transform.position = currentTile.transform.position;
            transform.SetParent(currentTile.transform);
            lastPos = currentTile.transform.position;

            Debug.Log(currentTile.position);
        }
        else
        {
            if(currentTile == null)
            {
                transform.position = lastPos;
            }
            else
            {
                transform.position = currentTile.gameObject.transform.position;
            }
            
        }

    }
}