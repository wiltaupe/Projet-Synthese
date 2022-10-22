using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private Vector3 dragOffset;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void OnMouseDown()
    {
        dragOffset = transform.position - GetMousePos();
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
        Collider2D col = Physics2D.OverlapPoint(GetMousePos(),LayerMask.GetMask("Sol"));
        if (col == null) return;
        this.transform.position = col.gameObject.transform.position;
    }
}
