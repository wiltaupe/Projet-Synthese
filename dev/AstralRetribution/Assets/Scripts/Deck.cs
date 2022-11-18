using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    public Deck()
    {
        Cartes = new();
        Main = new();
        Defausse = new();
    }
    public List<GameObject> Cartes { get; set; }
    public List<GameObject> Defausse { get; set; }
    public List<GameObject> Main { get; set; }
}