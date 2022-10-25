using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class PlaneteManager : MonoBehaviour
{
    GameObject planeteReg;
    public List<GameObject> planetes;
    public List<GameObject> actif;
    public float ray = 30f;

    public bool VerificationRayon(GameObject posi)
    {
        foreach (GameObject planete in actif)
        {

            double dx = Math.Pow(Math.Abs(posi.transform.position.x - planete.transform.position.x), 2);
            double dy = Math.Pow(Math.Abs(posi.transform.position.y - planete.transform.position.y), 2);
            double distance = Math.Sqrt(dx + dy);

            if (distance < 80f)
            {
                return true;
            }
        }
        return false;
    }

    public int min(GameObject posi)
    {
        Planete classePlanete = posi.GetComponent<Planete>();
        int max = classePlanete.VerificationPosition();
        int min = 0;

        foreach (GameObject planete in actif.OrderBy(x => Vector3.Distance(x.transform.position, new Vector3(-55f, -30f))).ToList())
        {
            Planete pospla = planete.GetComponent<Planete>();

            if (min > max && max > pospla.VerificationPosition())
            {
                min = pospla.VerificationPosition();
            }

        }

        return min;
    }

    public bool VerificationPossedeChemin(GameObject planete)
    {
        Planete classePlanete = planete.GetComponent<Planete>();

        foreach (GameObject verif in actif.OrderBy(x => Vector3.Distance(x.transform.position, new Vector3(-55f, -30f))).ToList())
        {
            Planete positionVerif = verif.GetComponent<Planete>();
            int minimum = min(planete);


            if ((classePlanete.VerificationPosition() == positionVerif.VerificationPosition() - minimum) && !classePlanete.possedeCheminDerriere)
            {
                if (minimum == 1)
                {
                    return false;
                }

                Debug.Log("Creation du chemin vers autre planete suplementaire");

                CreationLigne(planete, verif);
                classePlanete.possedeCheminDerriere = true;

                return true;
            }

            if (!classePlanete.possedeCheminDerriere)
            {
                foreach (GameObject verif2 in actif)
                {
                    Planete positionVerif2 = verif.GetComponent<Planete>();

                    double dx = Math.Pow(Math.Abs(planete.transform.position.x - verif2.transform.position.x), 2);
                    double dy = Math.Pow(Math.Abs(planete.transform.position.y - verif2.transform.position.y), 2);
                    double distance = Math.Sqrt(dx + dy);

                    if (minimum == positionVerif2.VerificationPosition() && distance < 400f)
                    {
                        CreationLigne(planete, verif);
                        classePlanete.possedeCheminDerriere = true;

                        return true;
                    }
                
                }
            }
        }
        return false;
    }

    public bool VerificationPath(GameObject planete) 
    {
        Planete classePlanete = planete.GetComponent<Planete>();

        foreach (GameObject verif in actif.OrderBy(x => Vector3.Distance(x.transform.position, new Vector3(-55f, -30f))).ToList())
        {
            Planete positionVerif = verif.GetComponent<Planete>();

            double dx = Math.Pow(Math.Abs(planete.transform.position.x - verif.transform.position.x), 2);
            double dy = Math.Pow(Math.Abs(planete.transform.position.y - verif.transform.position.y), 2);
            double distance = Math.Sqrt(dx + dy);

            if (classePlanete.VerificationPosition() == 1 && (classePlanete.VerificationPosition() + 1 == positionVerif.VerificationPosition()))
            {
                Debug.Log("Creation du chemin vers autre planete initial");

                CreationLigne(planete, verif);
                classePlanete.possedeCheminDevant = true;
                positionVerif.possedeCheminDerriere = true;

                return true;
            }

            if (distance < 160f && (classePlanete.VerificationPosition() < positionVerif.VerificationPosition()))
            {
                Debug.Log("Creation du chemin vers autre planete");

                CreationLigne(planete, verif);
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
                actif.Add(objet);
            }

            else
            {
                GameObject objet = GenererUnePlanete(selection);

                if (VerificationRayon(objet))
                {
                    Destroy(objet);
                }

                else
                {
                    actif.Add(objet);
                }
            }
        }
    }

    public void GenererPathPlanete()
    {
        foreach (GameObject planete in actif.OrderBy(x => Vector3.Distance(x.transform.position, new Vector3(-55f, -30f))).ToList())
        {
            VerificationPath(planete);
            VerificationPossedeChemin(planete);
        }
    }

}