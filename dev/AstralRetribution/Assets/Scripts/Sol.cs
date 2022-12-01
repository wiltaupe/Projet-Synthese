using System;
using UnityEngine;

public class Sol : Tile
{
    private Color startcolor;

    public float vie = 10;
    public Module Module { get; set; }
    public Objet Objet { get; set; }
    public Salle Parent { get; set; }
    public Vaisseau Vaisseau { get; set; }
    public Vector2 Position { get; set; }
    public GameObject MembreEquipage{ get; set; }

    private void OnEnable()
    {
        GameManager.OnPlayerTurnEnd += GameManager_OnPlayerTurnEnd;
    }

    private void GameManager_OnPlayerTurnEnd()
    {
        GetComponent<SpriteRenderer>().material.color = Color.white;
        Parent.RoomSelected = false;
    }

    private void OnMouseOver()
    {
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.carteSelected is CartePilotage && Vaisseau.gameObject.CompareTag("VaisseauEnnemi") && !Parent.RoomSelected && GameManager.Instance.RoomSelected == null)
            {
                //GetComponent<SpriteRenderer>().material.color = Color.red;
                foreach (Sol sol in Parent.Tuiles)
                {
                    sol.GetComponent<SpriteRenderer>().material.color = Color.red;                
                }
            }
            else if (!Parent.RoomSelected)
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
        if (!Parent.RoomSelected)
        {
            foreach (Sol sol in Parent.Tuiles)
            {
                sol.GetComponent<SpriteRenderer>().material.color = Color.white;
            }

        }
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.carteSelected is CartePilotage && Vaisseau.gameObject.CompareTag("VaisseauEnnemi"))
            {
                GameManager.Instance.RoomSelected = Parent;
                Parent.RoomSelected = true;
                GameManager.Instance.CardPlayed();
            }
        }
    }
}
