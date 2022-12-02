using System.Collections.Generic;
using UnityEngine;

public class Salle
{
    public int Width { get; set; }
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
    }
    public void RecevoirDegats(float puissance)
    {
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
