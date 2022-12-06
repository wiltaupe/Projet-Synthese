using System;
using System.Collections.Generic;
using UnityEngine;

public class Salle
{
    public int Width { get; set; }
    public float MaxVie { get; set; }
    public float CurrentVie { get; set; }
    public RectInt RectInt { get; set; }
    public int Height { get; set; }
    public List<Sol> Tuiles { get; set; }
    public bool RoomSelected { get; set; }

    public Salle(int width, int height,RectInt rectint)
    {
        Width = width;
        Height = height;
        RectInt = rectint;
    }

    public void  AddTiles(List<Sol> sols)
    {
        Tuiles = sols;
        MaxVie = 5 * Tuiles.Count;
        CurrentVie = MaxVie;
    }
    public void RecevoirDegats(float puissance)
    {
        Debug.Log(CurrentVie);

        foreach (Sol sol in Tuiles)
        {
            if (sol.Module != null)
            {
                sol.Module.RecevoirDegats(puissance);
            }

            if (sol.MembreEquipage != null)
            {
                sol.MembreEquipage.GetComponent<MembreEquipage>().RecevoirDegats(puissance);
            }
        }
        CurrentVie -= puissance;
        Debug.Log(CurrentVie);
        if (CurrentVie <= 0)
        {
            SalleDetruit();
        }
    }

    private void SalleDetruit()
    {
        foreach (Sol sol in Tuiles)
        {
            sol.gameObject.SetActive(false);
        }
    }

    public Sol GetMiddleSol()
    {
        foreach (Sol sol in Tuiles)
        {
            if (sol.Position.x == (int)RectInt.center.x && sol.Position.y == (int)RectInt.center.y)
            {
                return sol;
            }
            
        }

        return null;
    }
}
