using UnityEngine;

public class BSPTree
{
    public BSPTree Gauche { get; set; }
    public BSPTree Droite { get; set; }
    public RectInt Contenu { get; set; }

    public BSPTree(RectInt contenu)
    {
        Contenu = contenu;
    }
}