using System.Collections.Generic;

public class Salle
{
    public int Width { get; set; }
    public int Height { get; set; }
    public List<Sol> Tuiles { get; set; }
    public bool RoomSelected { get; set; }

    public Salle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public void  AddTiles(List<Sol> sols)
    {
        Tuiles = sols;
    }
    public void RecevoirDegats(float puissance)
    {
    }

    public Sol GetMiddleTile()
    {
        foreach (Sol sol in Tuiles)
        {
            if (sol.Position.x == (int)Width/2 && sol.Position.y == (int)Height/2)
            {
                return sol;
            }
            
        }
        return null;
    }
}
