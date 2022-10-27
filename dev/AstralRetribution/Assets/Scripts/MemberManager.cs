using System.Collections.Generic;
using UnityEngine;

public class MemberManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> membresPossible;

    public void GenererMembres(int v,Vaisseau vaisseau)
    {
        List<GameObject> membresEquipage = new();
        while(membresEquipage.Count != v)
        {
            membresEquipage.Add(PlacerMembre(GenererMembre(),vaisseau));
            
        }

        vaisseau.MembresEquipage = membresEquipage;
    }

    private GameObject PlacerMembre(GameObject membreEquipage, Vaisseau vaisseau)
    {
        Sol tuile = null;
        while(tuile == null)
        {
            tuile = vaisseau.GetRandomAvailableTile();
        }

        membreEquipage.transform.SetParent(tuile.transform);
        membreEquipage.transform.position = tuile.transform.position;
        tuile.MembreEquipage = membreEquipage;
        return membreEquipage;
    }

    private GameObject GenererMembre()
    {
        int randomInt = Random.Range(0, membresPossible.Count);
        return Instantiate(membresPossible[randomInt], transform.position, Quaternion.identity);
    }
}