using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class PlaneteManager : MonoBehaviour
{
    GameObject planeteReg;
    public List<GameObject> planetes;
    public Dictionary<int,(GameObject,int)> actif;
    public float ray = 30f;


    private void Start()
    {
        actif = new();
    }

    public double CalculDistance(float x1, float x2,float y1, float y2)
    {
        double dx = Math.Pow(Math.Abs(x1 - x2), 2);
        double dy = Math.Pow(Math.Abs(y1 - y2), 2);
        double distance = Math.Sqrt(dx + dy);

        return distance;
    }


    public bool VerificationRayon(GameObject posi,float rayon)
    {
        foreach (var planete in actif.Values)
        {
            if (CalculDistance(posi.transform.position.x, planete.Item1.transform.position.x, posi.transform.position.y, planete.Item1.transform.position.y) < rayon)
            {
                return true;
            }
        }
        return false;
    }

    public int min(int posi)
    {
        int max = posi;
        int min = 15;
        
         var arr = actif.ToArray();
         Array.Sort(arr, (a, b) => a.Value.Item2.CompareTo(b.Value.Item2)); 

        foreach (var planete in arr)
        {
            int pospla = planete.Value.Item2;

            if (min > (max - pospla))
            {
                min = max - pospla;
            }

        }

        return min;
    }

    public bool VerificationPossedeChemin(GameObject planete,int planetepos)
    {
        Planete classePlanete = planete.GetComponent<Planete>();

        foreach (var verif in actif.Values)
        {
            Planete positionVerif = verif.Item1.GetComponent<Planete>();
            int minimum = min(verif.Item2);

            if ((planetepos - minimum == verif.Item2) && !classePlanete.possedeCheminDerriere)
            {

                Debug.Log("Creation du chemin vers autre planete suplementaire");

                CreationLigne(planete, verif.Item1);
                classePlanete.possedeCheminDerriere = true;

                return true;
            }
        }
        return false;
    }

    public bool VerificationPath(GameObject planete,int planetepos) 
    {
        Planete classePlanete = planete.GetComponent<Planete>();

        foreach (var verif in actif.Values)
        {
            Planete positionVerif = verif.Item1.GetComponent<Planete>();
          
            double distance = CalculDistance(planete.transform.position.x, verif.Item1.transform.position.x, planete.transform.position.y, verif.Item1.transform.position.y);

            if (planetepos == 1 && (planetepos + 1 == verif.Item2))
            {
                Debug.Log("Creation du chemin vers autre planete initial");

                CreationLigne(planete, verif.Item1);
                classePlanete.possedeCheminDevant = true;
                positionVerif.possedeCheminDerriere = true;

                return true;
            }

            if (distance < 160f && (planetepos < verif.Item2))
            {
                Debug.Log("Creation du chemin vers autre planete");

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

    public GameObject GenererUnePlanete(GameObject position)
    {
        float x = UnityEngine.Random.Range(-55, 400);
        float y = UnityEngine.Random.Range(-205, 95);
        float rotation = UnityEngine.Random.Range(0, 360);

        GameObject objet = Instantiate(position, new Vector3(x, y), Quaternion.identity);
        objet.transform.Rotate(0, 0, rotation, Space.Self);

        return objet;
    }

    public void GenererPlanetes(int valeur)
    {
        for (int i = 0; i < valeur; i++)
        {
            int randomInt = UnityEngine.Random.Range(0, planetes.Count);
            float rotation = UnityEngine.Random.Range(0, 360);
            GameObject selection = planetes[randomInt];

            if (i == 0)
            {
                GameObject objet = Instantiate(selection, new Vector3(-55f, -30f), Quaternion.identity);
                objet.transform.Rotate(0, 0, rotation, Space.Self);
                Planete classePlanete = objet.GetComponent<Planete>();

                actif[0] = (objet, classePlanete.VerificationPosition());
            }

            else
            {
                GameObject objet = GenererUnePlanete(selection);
                Planete classePlanete = objet.GetComponent<Planete>();

                if (VerificationRayon(objet,80f))
                {
                    Destroy(objet);
                }

                else
                {
                    actif[actif.Count] = (objet, classePlanete.VerificationPosition());
                }
            }
        }
    }

    public void GenererPathPlanete()
    {
        foreach (var planete in actif.Values)
        {
            VerificationPath(planete.Item1,planete.Item2);
            VerificationPossedeChemin(planete.Item1, planete.Item2);
        }
    }

}