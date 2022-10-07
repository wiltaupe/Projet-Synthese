using System;
using System.Collections.Generic;
using UnityEngine;

public class GenerateurDeSalle
{
    public ArbreBinaire arbreBinaire;
    public int nbSalleVoulue;
    public Vector2 taille;
    private List<Vector2> listePoints;

    public GenerateurDeSalle(int nbSalleVoulue, Vector2 taille)
    {
        this.nbSalleVoulue = nbSalleVoulue;
        this.taille = taille;
        arbreBinaire = new ArbreBinaire();
        listePoints = new List<Vector2>();
        GenererPoints();
    }

    private void GenererPoints()
    {
        for (int i = 0; i < taille.x; i++)
        {
            for (int j = 0; j < taille.y; j++)
            {
                Vector2 vector2 = new Vector2(i, j);
                Debug.Log(vector2);
                listePoints.Add(vector2);
            }
        }
    }

    public void Division(NoeudArbre noeud,float pourcentage,bool noeudFait)
    {

    }

    public void AjouterPoints(Vector2[] vector2s)
    {

    }
    public void CreerSalle()
    {

    }

}