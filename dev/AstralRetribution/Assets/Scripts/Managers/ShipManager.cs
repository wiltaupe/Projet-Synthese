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
    [SerializeField] private int nbIterations;
    [SerializeField] private GameObject[] prefabVaisseau;
    [SerializeField] private GameObject[] prefabEnnemi;
    private bool mechant;

    private List<RectInt> rectInts;

    public Vaisseau GenererVaisseau(Vector3 position,bool ennemi)
    {
        Taille = 18; 
        GenererSalles(Taille, nbIterations);
        return CreerTuiles(CreerVaisseau(position,ennemi));
    }

    Vaisseau CreerVaisseau(Vector3 position,bool ennemi)
    {
        GameObject govaisseau;
        if (ennemi)
        {
            govaisseau = Instantiate(prefabEnnemi[UnityEngine.Random.Range(0, prefabVaisseau.Length)], position, Quaternion.identity);
            govaisseau.name = "VaisseauEnnemi";
            mechant = true;
        }
        else
        {
            govaisseau = Instantiate(prefabVaisseau[UnityEngine.Random.Range(0, prefabEnnemi.Length)], position, Quaternion.identity);
            govaisseau.name = "Vaisseau";
            mechant = false;
        }

        return govaisseau.GetComponent<Vaisseau>();
    }

    internal Vaisseau CreerTuiles(Vaisseau vaisseau)
    {
        float ajusterTileHW = (float)320 / (float)Taille;
        float ajustersize = (float)10 / (float)Taille;

        List<Salle> salles = new();
        List<Vector3> use = new();

        foreach (RectInt rectInt in rectInts)
        {
            Salle salle = new(rectInt.width, rectInt.height,rectInt,vaisseau);
            List<Sol> tiles = new();

            for (int i = rectInt.xMin; i <= rectInt.xMax; i++)
            {
                for (int j = rectInt.yMin; j <= rectInt.yMax; j++)
                {

                    if ((i == rectInt.xMin || i == rectInt.xMax || j == rectInt.yMin || j == rectInt.yMax) && (((i != (int)rectInt.center.x && j != (int)rectInt.center.y)) || (i == 0 || i == Taille || j == 0 || j == Taille)))
                    {
                        if (!use.Contains(new Vector3(i,j)))
                        {
                            Tile obj = Instantiate(mur, new Vector3(i * ajusterTileHW - (Taille / 2) * ajusterTileHW, j * ajusterTileHW - (Taille / 2) * ajusterTileHW) + vaisseau.transform.position, Quaternion.identity);
                            obj.transform.localScale = new Vector3(ajustersize, ajustersize, 0);
                            obj.transform.SetParent(vaisseau.transform.Find("Tuiles"));
                            obj.Position = new Vector2(i, j);
                            obj.name = $"Mur x:{i} y:{j}";
                            obj.Sol = false;
                            obj.Traversable = false;
                            use.Add(new Vector3(i, j));
                        }
                    }
                    else
                    {
                        if (!use.Contains(new Vector3(i, j)))
                        {
                            Sol obj = Instantiate(sol,new Vector3(i * ajusterTileHW - (Taille / 2)*ajusterTileHW, j * ajusterTileHW - (Taille / 2) * ajusterTileHW) + vaisseau.transform.position, Quaternion.identity);
                            obj.transform.localScale = new Vector3(ajustersize, ajustersize, 0);
                            obj.transform.SetParent(vaisseau.transform.Find("Tuiles"));
                            obj.Position = new Vector2(i, j);
                            obj.Parent = salle;
                            obj.Vaisseau = vaisseau;
                            obj.name = $"Sol x:{i} y:{j}";
                            obj.Traversable = true;
                            obj.Sol = true;
                            tiles.Add(obj);
                            use.Add(new Vector3(i, j));
                        }
                    }
                }
            }

            if (tiles.Count != 0)
            {
                salle.AddTiles(tiles);  
                salles.Add(salle);
            }
        }

        vaisseau.Salles = salles;
        vaisseau.mechant = mechant;
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
        // source : https://www.geeksforgeeks.org/print-leaf-nodes-left-right-binary-tree/ // If node is null, return

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
            c1 = new RectInt(contenu.x, contenu.y, contenu.width, (int)UnityEngine.Random.Range(contenu.height * 0.3f, contenu.height * 0.5f));
            c2 = new RectInt(contenu.x, contenu.y + c1.height, contenu.width, contenu.height - c1.height);
        }

        else
        {
            c1 = new RectInt(contenu.x, contenu.y, (int)UnityEngine.Random.Range(contenu.width * 0.3f, contenu.width * 0.5f), contenu.height);
            c2 = new RectInt(contenu.x + c1.width, contenu.y, contenu.width - c1.width, contenu.height);
        }

        return new RectInt[] { c1, c2 };
    }


}
