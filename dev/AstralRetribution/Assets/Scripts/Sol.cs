using System;
using UnityEngine;

public class Sol : Tile
{
    private Color startcolor;
    public GameObject cible;
    public float vie = 10;
    public Module Module { get; set; }
    public Objet Objet { get; set; }
    public Salle Parent { get; set; }
    public Vaisseau Vaisseau { get; set; }
    public Vector2 Position { get; set; }
    public GameObject MembreEquipage{ get; set; }
    public bool locked;

    internal void RecevoirDegats(float montant)
    {
        vie -= montant;
        Debug.Log(vie);
        if (vie <=0)
        {
            DesactiverSol();
        }
    }

    private void DesactiverSol()
    {
        gameObject.SetActive(false);
    }

    void OnMouseEnter()
    {
        startcolor = GetComponent<SpriteRenderer>().material.color;
        
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.carteSelected is CartePilotage && Vaisseau.gameObject.CompareTag("VaisseauEnnemi"))
            {
                //GetComponent<SpriteRenderer>().material.color = Color.red;
                cible.SetActive(true);
            }
            else
            {
                GetComponent<SpriteRenderer>().material.color = Color.yellow;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().material.color = Color.yellow;
        }



    }
    void OnMouseExit()
    {
        if (!locked)
        {
            cible.SetActive(false);
        }
        
        GetComponent<SpriteRenderer>().material.color = startcolor;
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.carteSelected is CartePilotage && Vaisseau.gameObject.CompareTag("VaisseauEnnemi"))
            {
                GameManager.Instance.solSelected = this;
                locked = true;
                cible.SetActive(true);
            }
        }
    }
}
