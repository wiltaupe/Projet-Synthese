using System;
using System.Collections.Generic;
using UnityEngine;
public class PlaneteManager : MonoBehaviour
{

    GameObject planeteReg;
    public static PlaneteManager Instance { get; private set; }
    public List<GameObject> planetes;
    public Dictionary<int, (GameObject, int)> actif = new();
    public float ray = 30f;
    public int position;
    public bool fait;

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
        Debug.Log(position);
    }

        public double CalculDistance(float x1, float x2, float y1, float y2)
    {
        double dx = Math.Pow(Math.Abs(x1 - x2), 2);
        double dy = Math.Pow(Math.Abs(y1 - y2), 2);
        double distance = Math.Sqrt(dx + dy);

        return distance;
    }


    public bool VerificationRayon(GameObject posi, float rayon)
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

    public int min(int posi, Dictionary<int, (GameObject, int)> dictionnaire)
    {
        int max = posi;
        int pos = 0;
        int min = 0;


        foreach (var planete in dictionnaire.Values)
        {
            int pospla = planete.Item2;

            if (min < pospla && pospla < max)
            {
                pos = pospla;
            }
        }

        return posi - pos;
    }

    public bool VerificationPossedeChemin(GameObject planete, int planetepos)
    {
        Planete classePlanete = planete.GetComponent<Planete>();

        foreach (var verif in actif.Values)
        {
            if ((planetepos - min(planetepos, actif) == verif.Item2) && !classePlanete.possedeCheminDerriere)
            {
                CreationLigne(planete, verif.Item1);
                classePlanete.possedeCheminDerriere = true;

                return true;
            }
        }


        return false;
    }

    public bool VerificationPath(GameObject planete, int planetepos)
    {
        Planete classePlanete = planete.GetComponent<Planete>();

        foreach (var verif in actif.Values)
        {
            Planete positionVerif = verif.Item1.GetComponent<Planete>();

            double distance = CalculDistance(planete.transform.position.x, verif.Item1.transform.position.x, planete.transform.position.y, verif.Item1.transform.position.y);

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

    public GameObject GenererUnePlanete(GameObject planete)
    {
        float x = UnityEngine.Random.Range(-55, 400);
        float y = UnityEngine.Random.Range(-205, 95);
        float rotation = UnityEngine.Random.Range(0, 360);

        GameObject objet = Instantiate(planete, new Vector3(x, y), Quaternion.identity);
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
                GameObject objet = Instantiate(selection, new Vector3(-55, 95), Quaternion.identity);
                objet.transform.Rotate(0, 0, rotation, Space.Self);
                Planete classePlanete = objet.GetComponent<Planete>();
                actif[0] = (objet, classePlanete.VerificationPosition());
            }

            else
            {
                GameObject objet = GenererUnePlanete(selection);
                Planete classePlanete = objet.GetComponent<Planete>();

                if (VerificationRayon(objet, 80f))
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

    public void Gener()
    {
    
    
    }

    public void GenererPathPlanete()
    {
        foreach (var planete in actif.Values)
        {
            VerificationPath(planete.Item1, planete.Item2);
            VerificationPossedeChemin(planete.Item1, planete.Item2);
        }
    }

    public void SetPosition(int p)
    {
        position = p;
    }

}