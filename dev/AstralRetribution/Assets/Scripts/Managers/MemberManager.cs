using System.Collections.Generic;
using UnityEngine;


public class MemberManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> membresPossible;

    public void GenererMembres(int v,Vaisseau vaisseau, bool ennemi)
    {
        List<GameObject> membresEquipage = new();
        while(membresEquipage.Count != v)
        {
            membresEquipage.Add(PlacerMembre(GenererMembre(),vaisseau,ennemi));
        }

        vaisseau.MembresEquipage = membresEquipage;
    }

    private GameObject PlacerMembre(GameObject membreEquipage, Vaisseau vaisseau,bool ennemi)
    {
        Sol tuile = null;
        while(tuile == null)
        {
            tuile = vaisseau.GetRandomAvailableTile();
        }

        membreEquipage.transform.SetParent(tuile.transform);
        membreEquipage.transform.position = tuile.transform.position;

        membreEquipage.GetComponent<MembreEquipage>().tuile = tuile;
        membreEquipage.GetComponent<MembreEquipage>().ennemi = ennemi;
        membreEquipage.GetComponent<MembreEquipage>().vaisseau = vaisseau;

        tuile.MembreEquipage = membreEquipage;
        return membreEquipage;
    }

    private GameObject GenererMembre()
    {
        float ajustersize = (float)8 / (float)ShipManager.Taille;

        int randomInt = Random.Range(0, membresPossible.Count);
        GameObject member= Instantiate(membresPossible[randomInt], transform.position, Quaternion.identity);

        member.transform.localScale = new Vector3(ajustersize, ajustersize, 0);
        return member;
    }
}