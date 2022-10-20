using System;
using System.Collections.Generic;
using UnityEngine;
public class PlaneteManager : MonoBehaviour
{
    GameObject planeteReg;
    public List<Planete> planetes;
    public void GenererPlanete()
    {
        int ite = 0;

        foreach (Planete planete in planetes)
        {
            if (ite == 0)
            {
                Instantiate(planete, new Vector3(-55f, -30f), Quaternion.identity);
                ite += 1;
            }

            else
            {
                float x = UnityEngine.Random.Range(-5, 400);
                float y = UnityEngine.Random.Range(-205, 95);

                Instantiate(planete, new Vector3(x, y), Quaternion.identity);
            }
        }
    }
}