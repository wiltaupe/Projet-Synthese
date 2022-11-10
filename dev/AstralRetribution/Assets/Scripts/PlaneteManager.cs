using System;
using System.Collections.Generic;
using UnityEngine;
public class PlaneteManager : MonoBehaviour
{

    GameObject planeteReg;
    public static PlaneteManager Instance { get; private set; }
    public List<GameObject> planetes;
    private Dictionary<int, (Vector3 vecteurPosition,float rotationZ, int position, int selection)> actif = new();
    private int position;
    private bool fait;
    private bool debut = false;
    private float[] tab;


    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        this.transform.SetParent(GameObject.Find("MainManager").transform);
    }

    public int VerificationPosition(float x)
    {
        int position = 11;

        for (double i = (x + 55); i < 455; i += 45.5)
        {
            position -= 1;
        }

        return position;
    }

    public double CalculDistance(float x1, float x2, float y1, float y2)
    {
        double dx = Math.Pow(Math.Abs(x1 - x2), 2);
        double dy = Math.Pow(Math.Abs(y1 - y2), 2);
        double distance = Math.Sqrt(dx + dy);

        return distance;
    }


    public bool VerificationRayon(float x,float y, float rayon)
    {
        foreach (var planete in actif.Values)
        {
            if (CalculDistance(x, planete.vecteurPosition.x, y, planete.vecteurPosition.y) < rayon)
            {
                return true;
            }
        }
        return false;
    }

    public int min(int posi, List<(GameObject, int)> list)
    {
        int max = posi;
        int pos = 0;
        int min = 0;


        foreach (var planete in list)
        {
            int pospla = planete.Item2;

            if (min < pospla && pospla < max)
            {
                pos = pospla;
            }
        }

        return posi - pos;
    }

    public bool VerificationPossedeChemin(GameObject planete, int planetepos, List<(GameObject, int)> pla)
    {
        Planete classePlanete = planete.GetComponent<Planete>();

        foreach (var verif in pla)
        {
            if ((planetepos - min(planetepos, pla) == verif.Item2) && !classePlanete.possedeCheminDerriere)
            {
                CreationLigne(planete, verif.Item1);
                classePlanete.possedeCheminDerriere = true;

                return true;
            }
        }


        return false;
    }

    public bool VerificationPath(GameObject planete, int planetepos, List<(GameObject, int)> pla)
    {
        Planete classePlanete = planete.GetComponent<Planete>();

        foreach (var verif in pla)
        {
            Planete positionVerif = verif.Item1.GetComponent<Planete>();

            double distance = CalculDistance(classePlanete.transform.position.x, positionVerif.transform.position.x, classePlanete.transform.position.y, positionVerif.transform.position.y);

            if (planetepos == 1 && (planetepos + 1 == verif.Item2))
            {
                CreationLigne(planete, verif.Item1);
                classePlanete.possedeCheminDevant = true;
                positionVerif.possedeCheminDerriere = true;

                return true;
            }

            if (distance < 160f && (planetepos < verif.Item2))
            {
                CreationLigne(planete, verif.Item1);
                classePlanete.possedeCheminDevant = true;
                positionVerif.possedeCheminDerriere = true;

                return true;
            }
        }

        return false;
    }

    public void CreationLigne(GameObject ini, GameObject fin)
    {
        var go = new GameObject();
        var lr = go.AddComponent<LineRenderer>();

        lr.SetPosition(0, ini.transform.position);
        lr.SetPosition(1, fin.transform.position);
    }

    public (float,float,float) GenererUnePlanete()
    {
        float x = UnityEngine.Random.Range(-55, 400);
        float y = UnityEngine.Random.Range(-205, 95);
        float rotation = UnityEngine.Random.Range(0, 360);

        return (x,y, rotation);
    }

    /******************************************************/
    /* https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm */

    /*
    private double DistancePLanete(GameObject p1, GameObject p2)
    {
        return Math.Sqrt(Math.Pow(p2.transform.position.x - p1.transform.position.x, 2) + Math.Pow(p2.transform.position.y - p1.transform.position.y, 2));
    }

    private void Dijkstra(List<GameObject> pla, GameObject planeteSource)
    {
        Dijk[planeteSource]; //= 0;                    // Distance from source to source is set to 0
       foreach (vertex v in pla)            // Initializations
        {
           if v ≠ source
                dist[v]  := infinity           // Unknown distance function from source to each node set to infinity
           add v to Q                         // All nodes initially in Q
        }

      while Q is not empty:                  // The main loop
          v:= vertex in Q with min dist[v]  // In the first run-through, this vertex is the source node
          remove v from Q

          for each neighbor u of v:           // where neighbor u has not yet been removed from Q.
              alt := dist[v] + length(v, u)
              if alt < dist[u]:               // A shorter path to u has been found
                  dist[u]  := alt            // Update distance of u 

      return dist[]
      }

    */

    /******************************************************/

    public void GenererPlanetes(int valeur)
    {
        for (int i = 0; i < valeur; i++)
        {
            int randomInt = UnityEngine.Random.Range(0, planetes.Count);
            float rotation = UnityEngine.Random.Range(0, 360);

            if (i == 0)
            {
                actif[0] = (new Vector3(-55, 95),rotation,VerificationPosition(-55), randomInt);
            }

            else
            {
                var objet = GenererUnePlanete();

                if (!VerificationRayon(objet.Item1,objet.Item2, 80f))
                {
                    actif[actif.Count] = (new Vector3(objet.Item1, objet.Item2), objet.Item3, VerificationPosition(objet.Item1), randomInt);
                }
            }
        }
    }

    public void GenererPathPlanete(GameObject path, int pathPosition, List<(GameObject, int)> pla)
    {
        VerificationPath(path, pathPosition,pla);
        VerificationPossedeChemin(path, pathPosition,pla);
    }


    public void PlacerActif()
    {
        List<(GameObject, int)> pla = new();

        for (int i = 0; i < actif.Count; i++)
        {
            GameObject selection = planetes[actif[i].selection];
            GameObject c = Instantiate(selection, actif[i].vecteurPosition,Quaternion.identity);
            c.transform.Rotate(0, 0, actif[i].rotationZ, Space.Self);
            pla.Add((c, actif[i].position));
        }

        foreach (var item in pla)
        {
            GenererPathPlanete(item.Item1,item.Item2,pla);
            item.Item1.transform.SetParent(GameObject.Find("ObjetPlanete").transform);
        }
    }

    public int GetPosition()
    {
        return position;
    }

    public bool GetDebut()
    {
        return debut;
    }

    public bool GetFait()
    {
        return fait;
    }

    public void SetPosition(int p)
    {
        position = p;
    }

    public void SetDebut(bool d)
    {
        debut = d;
    }

    public void SetFait(bool f)
    {
        fait = f;
    }


}