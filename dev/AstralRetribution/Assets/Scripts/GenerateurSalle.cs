using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateurSalle : MonoBehaviour
{
    public int tailleVaisseau;
    [Range(1, 10)]
    public int nbIterations;
    private BSPTree tree;
    private readonly bool shouldDebugDrawBsp = true;

    private float ratio;

    public void Start()
    {
        GenererVaisseau();

    }

    // Start is called before the first frame update
    public void GenererVaisseau()
    {
        tree = Division(nbIterations, new RectInt(0, 0, tailleVaisseau, tailleVaisseau));
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

        if(Random.Range(0f,1f) > 0.5f)
        {

            // vertical split
            c1 = new RectInt(contenu.x, contenu.y, contenu.width, (int)Random.Range(contenu.height * 0.3f,contenu.height * 0.5f));
            c2 = new RectInt(contenu.x, contenu.y + c1.height, contenu.width, contenu.height - c1.height);

            /*
             * ratio pour egaliser  ////// % split x ou y par 50/50 augmentatiion 25% / - 25 %
             * float c1WRatio = c1.width / c1.height;
            float c2WRatio = c2.width / c2.height;
            if (c1WRatio < ratio || c2WRatio < ratio)
            {
                return DiviserContenu(contenu);
            }*/

        }
        else
        {
            // horizontal split
            c1 = new RectInt(contenu.x, contenu.y, (int)Random.Range(contenu.width * 0.3f,contenu.width * 0.5f), contenu.height);
            c2 = new RectInt(contenu.x + c1.width, contenu.y, contenu.width - c1.width, contenu.height);

        }

        return new RectInt[] { c1, c2 };
    }

    void OnDrawGizmos()
    {
        AttemptDebugDrawBsp();
    }

    private void OnDrawGizmosSelected()
    {
        AttemptDebugDrawBsp();
    }

    void AttemptDebugDrawBsp()
    {
        if (shouldDebugDrawBsp)
        {
            DebugDrawBsp();
        }
    }

    public void DebugDrawBsp()
    {
        if (tree == null) return; // hasn't been generated yet

        DebugDrawBspNode(tree); // recursive call
    }

    public void DebugDrawBspNode(BSPTree node)
    {


        // Container
        Gizmos.color = Color.green;
        // top
        Gizmos.DrawLine(new Vector3(node.Contenu.x, node.Contenu.y, 0), new Vector3Int(node.Contenu.xMax, node.Contenu.y, 0));
        // right
        Gizmos.DrawLine(new Vector3(node.Contenu.xMax, node.Contenu.y, 0), new Vector3Int(node.Contenu.xMax, node.Contenu.yMax, 0));
        // bottom
        Gizmos.DrawLine(new Vector3(node.Contenu.x, node.Contenu.yMax, 0), new Vector3Int(node.Contenu.xMax, node.Contenu.yMax, 0));
        // left
        Gizmos.DrawLine(new Vector3(node.Contenu.x, node.Contenu.y, 0), new Vector3Int(node.Contenu.x, node.Contenu.yMax, 0));

        // children
        if (node.Gauche != null) DebugDrawBspNode(node.Gauche);
        if (node.Droite != null) DebugDrawBspNode(node.Droite);
    }
}
