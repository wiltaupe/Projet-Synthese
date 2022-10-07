using System;
using UnityEngine;

public class GenerateurDeSalle
{
    public ArbreBinaire arbreBinaire;
    public int nbSalleVoulue;
    public Vector2 taille;
    private Vector2[] points;

    public GenerateurDeSalle(int nbSalleVoulue, Vector2 taille)
    {
        this.nbSalleVoulue = nbSalleVoulue;
        this.taille = taille;
        arbreBinaire = new ArbreBinaire();
        GenererPoints();
    }

    private void GenererPoints()
    {
        for (int i = 0; i < taille.x; i++)
        {
            for (int j = 0; j < taille.y; j++)
            {
                
            }
        }
    }

    public void Division(NoeudArbre noeud,float pourcentage,bool noeudFait)
    {

    }
    public void CreerSalle()
    {

    }

}