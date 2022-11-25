using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShipManager : MonoBehaviour
{
    [SerializeField] private Tile mur;
    [SerializeField] private Sol sol;
    [SerializeField] private Porte porte;
    public static int Taille { get; private set; }
    //[SerializeField] public int taille { get; set; }
    [SerializeField] private int nbIterations;
    [SerializeField] private GameObject prefabVaisseau;
    [SerializeField] private GameObject prefabEnnemi;

    private List<RectInt> rectInts;

    public Vaisseau GenererVaisseau(Vector2 position,bool ennemi)
    {
        Taille = 18; 
        GenererSalles(Taille, nbIterations);
        return CreerTuiles(CreerVaisseau(position,ennemi));
    }

    private Vaisseau CreerVaisseau(Vector2 position,bool ennemi)
    {
        GameObject goVaisseau;
        if (ennemi)
        {
            goVaisseau = Instantiate(prefabEnnemi, position, Quaternion.identity);
            goVaisseau.name = "VaisseauEnnemi";
        }
        else
        {
            goVaisseau = Instantiate(prefabVaisseau, position, Quaternion.identity);
            goVaisseau.name = "Vaisseau";
        }

        
        return goVaisseau.GetComponent<Vaisseau>();
    }

    internal Vaisseau CreerTuiles(Vaisseau vaisseau)
    {
        float ajusterTileHW = (float)320 / (float)Taille;
        float ajustersize = (float)10 / (float)Taille;

        List<Salle> salles = new();
        List<Vector3> use = new();

        foreach (RectInt rectInt in rectInts)
        {
            List<Sol> tiles = new();

            for (int i = rectInt.xMin; i <= rectInt.xMax; i++)
            {
                for (int j = rectInt.yMin; j <= rectInt.yMax; j++)
                {

                    if ((i == rectInt.xMin || i == rectInt.xMax || j == rectInt.yMin || j == rectInt.yMax) && (((i != (int)rectInt.center.x && j != (int)rectInt.center.y)) || (i == 0 || i == Taille || j == 0 || j == Taille)))
                    {
                        if (!use.Contains(new Vector3(i,j)))
                        {
                            var obj = Instantiate(mur, new Vector3(i * ajusterTileHW, j * ajusterTileHW) + vaisseau.transform.position, Quaternion.identity);
                            obj.transform.localScale = new Vector3(ajustersize, ajustersize, 0);
                            obj.transform.SetParent(vaisseau.transform.Find("Tuiles"));
                            use.Add(new Vector3(i, j));
                        }
                    }
                    else
                    {
                        if (!use.Contains(new Vector3(i, j)))
                        {
                            Sol obj = Instantiate(sol, new Vector3(i * ajusterTileHW, j * ajusterTileHW) + vaisseau.transform.position, Quaternion.identity);
                            obj.transform.localScale = new Vector3(ajustersize, ajustersize, 0);
                            obj.transform.SetParent(vaisseau.transform.Find("Tuiles"));
                            obj.Position = new Vector2(i, j);
                            obj.Vaisseau = vaisseau;
                            obj.name = $"Sol x:{i} y:{j}";
                            tiles.Add(obj);
                            use.Add(new Vector3(i, j));
                        }
                    }

                    /*if (rectInt.xMin != 0)
                    {

                        var obj = Instantiate(porte, new Vector3(rectInt.xMin * ajusterTileHW, (int)rectInt.center.y * ajusterTileHW) + vaisseau.transform.position, Quaternion.identity);
                        obj.transform.localScale = new Vector3(ajustersize, ajustersize, 0);
                        obj.transform.SetParent(vaisseau.transform.Find("Tuiles"));
                        obj.transform.Rotate(0, 0, 90, Space.Self);
                    }

                    if (rectInt.xMax != Taille)
                    {
                        var obj = Instantiate(porte, new Vector3(rectInt.xMax * ajusterTileHW, (int)rectInt.center.y * ajusterTileHW) + vaisseau.transform.position, Quaternion.identity);
                        obj.transform.localScale = new Vector3(ajustersize, ajustersize, 0);
                        obj.transform.SetParent(vaisseau.transform.Find("Tuiles"));
                        obj.transform.Rotate(0, 0, 90, Space.Self);
                    }

                    if (rectInt.yMin != 0)
                    {
                        var obj = Instantiate(porte, new Vector3((int)rectInt.center.x * ajusterTileHW, rectInt.yMin * ajusterTileHW) + vaisseau.transform.position, Quaternion.identity);
                        obj.transform.localScale = new Vector3(ajustersize, ajustersize, 0);
                        obj.transform.SetParent(vaisseau.transform.Find("Tuiles"));
                    }

                    if (rectInt.yMax != Taille)
                    {
                        var obj = Instantiate(porte, new Vector3((int)rectInt.center.x * ajusterTileHW, rectInt.yMax * ajusterTileHW) + vaisseau.transform.position, Quaternion.identity);
                        obj.transform.localScale = new Vector3(ajustersize, ajustersize, 0);
                        obj.transform.SetParent(vaisseau.transform.Find("Tuiles"));
                    }*/
                }
            }

            if (tiles.Count != 0)
            {
                Salle salle = new(rectInt.width /** (int)ajusterTile*/, rectInt.height /** (int)ajusterTile*/, tiles);
                salles.Add(salle);
            }





            
        }

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

            /*try
            {
                if (c1.height <= 2 || c2.height <= 2 || c1.width <= 2 || c2.width <= 2)
                {
                    DiviserContenu(contenu);
                }
            }
            catch (StackOverflowException)
            {
                GenererSalles(Taille, nbIterations);
            }*/

            //ratio pour egaliser  ////// % split x ou y par 50/50 augmentatiion 25% / - 25 %
        }

        else
        {
            // horizontal split
            c1 = new RectInt(contenu.x, contenu.y, (int)UnityEngine.Random.Range(contenu.width * 0.3f, contenu.width * 0.5f), contenu.height);
            c2 = new RectInt(contenu.x + c1.width, contenu.y, contenu.width - c1.width, contenu.height);

            /*try
            {
                if (c1.height <= 2 || c2.height <= 2 || c1.width <= 2 || c2.width <= 2)
                {
                    DiviserContenu(contenu);
                }
            }
            catch (StackOverflowException)
            {
                GenererSalles(Taille, nbIterations);
            }*/

        }


        return new RectInt[] { c1, c2 };
    }


}
