using System;
using System.Collections.Generic;
using UnityEngine;

public class GenerateurDeSalle
{
    private Arbre arbre;
    private int taille = 400;
    private int nbIterations;

    public GenerateurDeSalle(int nbIterations)
    {
        this.nbIterations = nbIterations;
    }

    public void CreerArbre()
    {
        List<Vector2> liste = new();
        for (int i=0; i < 20; i++)
        {
            for(int j=0; j < 20; j++)
            {
                liste.Add(new Vector2(i, j));
            }
        }
        
        arbre = new Arbre(liste);

        Iteration(arbre.racine, nbIterations) ;
    }

    private void Iteration(Noeud noeud, int nbIterations)
    {
        if (nbIterations > 0)
        {
            int randomInt = UnityEngine.Random.Range(0, 2);
            Diviser(noeud, randomInt);
            
        }
    }

    private void Diviser(Noeud noeud, int horizontalVertical)
    {
        if (horizontalVertical == 1)
        {
            // horizontal
            float mx = noeud.points[0][1];
            float mn = noeud.points[0][1];

            for (int i = 0; i < noeud.points.Count; i++)
            {
                if (noeud.points[i][1] > mx)
                {
                    mx = noeud.points[i][1];
                }


                if (noeud.points[i][1] < mn)
                {
                    mn = noeud.points[i][1];
                }
            }

            


            Debug.Log(mn);
            Debug.Log(mx);
        }
        else if (horizontalVertical == 0)
        {
            // vertical
            float mx = noeud.points[0][0];
            float mn = noeud.points[0][0];

            for (int i = 0; i < noeud.points.Count; i++)
            {
                if (noeud.points[i][1] > mx)
                {
                    mx = noeud.points[i][0];
                }


                if (noeud.points[i][1] < mn)
                {
                    mn = noeud.points[i][0];
                }
            }

            Debug.Log(mn);
            Debug.Log(mx);
        }
    }

    internal void GenererVaisseau()
    {
        CreerArbre();

    }
}