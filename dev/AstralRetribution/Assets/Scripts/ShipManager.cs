using System;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    [SerializeField] private Tile mur;
    [SerializeField] private Sol sol;
    [SerializeField] private Porte porte;
    [SerializeField] private int tileSize = 32;
    [SerializeField] private int taille;
    [SerializeField] private int nbIterations;
    [SerializeField] private GameObject prefabVaisseau;
    private List<RectInt> rectInts;

    public Vaisseau GenererVaisseau(Vector2 position)
    {
        GenererSalles(taille, nbIterations);

        return CreerTuiles(CreerVaisseau(position));
    }

    private Vaisseau CreerVaisseau(Vector2 position)
    {
        GameObject goVaisseau = Instantiate(prefabVaisseau, position, Quaternion.identity);

        goVaisseau.name = "Vaisseau";
        return goVaisseau.GetComponent<Vaisseau>();
    }

    internal Vaisseau CreerTuiles(Vaisseau vaisseau)
    {

        List<Salle> salles = new();


        foreach (RectInt rectInt in rectInts)
        {
            List<Sol> tiles = new();
            for (int i = rectInt.xMin; i <= rectInt.xMax; i++)
            {
                for (int j = rectInt.yMin; j <= rectInt.yMax; j++)
                {

                    if (i == rectInt.xMin || i == rectInt.xMax || j == rectInt.yMin || j == rectInt.yMax)
                    {

                        var obj = Instantiate(mur, new Vector3(i * tileSize, j * tileSize) + vaisseau.transform.position, Quaternion.identity);
                        obj.transform.SetParent(vaisseau.transform.Find("Tuiles"));


                    }
                    else
                    {
                        Sol obj = Instantiate(sol, new Vector3(i * tileSize, j * tileSize) + vaisseau.transform.position, Quaternion.identity);
                        obj.transform.SetParent(vaisseau.transform.Find("Tuiles"));
                        obj.position = new Vector2(i, j);
                        tiles.Add(obj);
                        obj.name = $"Sol x:{i} y:{j}";
                    }

                    if (rectInt.xMin != 0)
                    {

                        var obj = Instantiate(porte, new Vector3(rectInt.xMin * tileSize, (int)rectInt.center.y * tileSize) + vaisseau.transform.position, Quaternion.identity);
                        obj.transform.SetParent(vaisseau.transform.Find("Tuiles"));
                        obj.transform.Rotate(0, 0, 90, Space.Self);

                    }

                    if (rectInt.xMax != taille)
                    {
                        var obj = Instantiate(porte, new Vector3(rectInt.xMax * tileSize, (int)rectInt.center.y * tileSize) + vaisseau.transform.position, Quaternion.identity);
                        obj.transform.SetParent(vaisseau.transform.Find("Tuiles"));
                        obj.transform.Rotate(0, 0, 90, Space.Self);
                    }

                    if (rectInt.yMin != 0)
                    {
                        var obj = Instantiate(porte, new Vector3((int)rectInt.center.x * tileSize, rectInt.yMin * tileSize) + vaisseau.transform.position, Quaternion.identity);
                        obj.transform.SetParent(vaisseau.transform.Find("Tuiles"));
                    }

                    if (rectInt.yMax != taille)
                    {
                        var obj = Instantiate(porte, new Vector3((int)rectInt.center.x * tileSize, rectInt.yMax * tileSize) + vaisseau.transform.position, Quaternion.identity);
                        obj.transform.SetParent(vaisseau.transform.Find("Tuiles"));
                    }




                }
            }

            if (tiles.Count != 0)
            {
                Salle salle = new(rectInt.width, rectInt.height, tiles);
                salles.Add(salle);
            }





            
        }
        Debug.Log(salles);

        vaisseau.Salles = salles;
        return vaisseau;
    }




    public void GenererSalles(int taille, int nbIterations)
    {
        BSPTree tree;
        try
        {
            tree = Division(nbIterations, new RectInt(0, 0, taille, taille));
            rectInts = new();
            PrendreRectDansArbre(tree);

        }
        catch (DivideByZeroException)
        {
            GenererSalles(taille, nbIterations);
        }
    }
    private void PrendreRectDansArbre(BSPTree noeud)
    {
        // source : https://www.geeksforgeeks.org/print-leaf-nodes-left-right-binary-tree/
        // If node is null, return
        if (noeud == null)
            return;


        if (noeud.Gauche == null &&
            noeud.Droite == null)
        {
            rectInts.Add(noeud.Contenu);
        }


        if (noeud.Gauche != null)
            PrendreRectDansArbre(noeud.Gauche);

        if (noeud.Droite != null)
            PrendreRectDansArbre(noeud.Droite);
    }

    private BSPTree Division(int nbIterations, RectInt contenu)
    {
        BSPTree noeud = new(contenu);
        if (nbIterations == 0) return noeud;

        RectInt[] contenusSplit = DiviserContenu(contenu);
        noeud.Gauche = Division(nbIterations - 1, contenusSplit[0]);
        noeud.Droite = Division(nbIterations - 1, contenusSplit[1]);

        return noeud;
    }

    private RectInt[] DiviserContenu(RectInt contenu)
    {
        RectInt c1, c2;

        if (UnityEngine.Random.Range(0f, 1f) > 0.5f)
        {

            // vertical split
            c1 = new RectInt(contenu.x, contenu.y, contenu.width, (int)UnityEngine.Random.Range(contenu.height * 0.3f, contenu.height * 0.5f));
            c2 = new RectInt(contenu.x, contenu.y + c1.height, contenu.width, contenu.height - c1.height);


            //ratio pour egaliser  ////// % split x ou y par 50/50 augmentatiion 25% / - 25 %
        }
        else
        {
            // horizontal split
            c1 = new RectInt(contenu.x, contenu.y, (int)UnityEngine.Random.Range(contenu.width * 0.3f, contenu.width * 0.5f), contenu.height);
            c2 = new RectInt(contenu.x + c1.width, contenu.y, contenu.width - c1.width, contenu.height);


        }


        return new RectInt[] { c1, c2 };
    }


}
