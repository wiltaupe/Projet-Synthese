using UnityEngine;

public class Planete : MonoBehaviour
{
    GameObject cercle;

    void Start()
    {
        cercle = transform.GetChild(0).gameObject;
    }

    private void OnMouseEnter()
    {
        Debug.Log("Pizza Time");
        cercle.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnMouseExit()
    {
        Debug.Log("Bye");
        cercle.GetComponent<SpriteRenderer>().enabled = false;
    }
}