using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunHeal : Module
{
    public override Etat Type { get; set; } = Etat.passif;
    private bool HealTime = false;

    void Update()
    {
        if (Type == Etat.passif && salleModule != null)
        {
            foreach (Sol sol in salleModule.Tuiles)
            {
                if (sol.MembreEquipage != null && HealTime == false)
                {
                    HealTime = true;
                    StartCoroutine(MiseAJourHeal(sol.MembreEquipage.GetComponent<MembreEquipage>()));
                }
            }
        }
    }

    private IEnumerator MiseAJourHeal(MembreEquipage m)
    {
        yield return new WaitForSeconds(1f);
        if(m.CurrentVie < m.MaxVie)
        {
            m.CurrentVie += 1;
        }
        HealTime = false;
        yield return new WaitForSeconds(1f);
    }
}
