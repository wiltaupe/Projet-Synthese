using System;
using System.Collections.Generic;
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
            Debug.Log(planete.transform.position.x);
            Debug.Log(planete.transform.position.y);

            double dx = Math.Pow(Math.Abs(posi.transform.position.x - planete.transform.position.x), 2);
            double dy = Math.Pow(Math.Abs(posi.transform.position.y - planete.transform.position.y), 2);
            double distance = Math.Sqrt(dx + dy);

            if (distance < 80f)
            {
                Debug.Log("Impossible de creer planete");

                return true;
            }
        }
        return false;
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

}