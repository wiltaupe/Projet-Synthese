using UnityEngine;

public class Sol : Tile
{
    private Color startcolor;
    public GameObject cible;
    public Module Module { get; set; }
    public Objet Objet { get; set; }
    public Salle Parent { get; set; }
    public Vaisseau Vaisseau { get; set; }
    public Vector2 Position { get; set; }
    public GameObject MembreEquipage{ get; set; }

    void OnMouseEnter()
    {
        startcolor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.yellow;
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.attackSelected && Vaisseau.gameObject.CompareTag("VaisseauEnnemi"))
            {
                GetComponent<Renderer>().material.color = Color.red;
                cible.SetActive(true);
            }
        }
        
        
    }
    void OnMouseExit()
    {
        cible.SetActive(false);
        GetComponent<Renderer>().material.color = startcolor;
    }

    private void OnMouseDown()
    {
        Debug.Log(Vaisseau);
    }
}
