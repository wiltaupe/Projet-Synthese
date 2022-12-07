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
    public Dictionary<int,GameObject> Cartes { get; set; }
    public Dictionary<int, GameObject> Defausse { get; set; }
    public Dictionary<int,GameObject> Main { get; set; }
}