using System;
using UnityEngine;

public class Sol : Tile
{

    public Module Module { get; set; }
    public Objet Objet { get; set; }
    public Salle Parent { get; set; }
    public Vaisseau Vaisseau { get; set; }
    public GameObject MembreEquipage{ get; set; }

    private void OnEnable()
    {
        GameManager.OnPlayerTurnEnd += GameManager_OnPlayerTurnEnd;
    }

    private void GameManager_OnPlayerTurnEnd()
    {
        Parent.RoomSelected = false;
        Parent.isProtected = false;
        if (this)
        {
            GetComponent<SpriteRenderer>().material.color = Color.white;
        }
    }

    private void OnMouseOver()
    {
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.CarteSelected is CartePilotage && Vaisseau.gameObject.CompareTag("VaisseauEnnemi") && !Parent.RoomSelected && GameManager.Instance.RoomSelected == null)
            {
                foreach (Sol sol in Parent.Tuiles)
                {
                    sol.GetComponent<SpriteRenderer>().material.color = Color.magenta;        
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
            if (GameManager.Instance.CarteSelected is CartePilotage && Vaisseau.gameObject.CompareTag("VaisseauEnnemi") && GameManager.Instance.RoomSelected == null)
            {
                GameManager.Instance.RoomSelected = Parent;
                Parent.RoomSelected = true;
                GameManager.Instance.CardPlayed();
            }
        }
    }
}
