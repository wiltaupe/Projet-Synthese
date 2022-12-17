using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporteur : Module
{
    public override Etat Type { get; set; } = Etat.actif;
    public override bool Teleport { get; set; } = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Equipage")
        {
            if (!collision.gameObject.GetComponentInParent<MembreEquipage>().ennemi && collision.GetComponentInParent<MembreEquipage>() is not Clone)
            {
                Vaisseau = GameObject.Find("Vaisseau").GetComponent<Vaisseau>();

                if (Vaisseau.possedeTeleporteurRecepteur)
                {
                    Transform membre = collision.gameObject.transform.parent;
                    Debug.Log("je teleporte");
                    Debug.Log(Vaisseau.positionRecepteur);
                    membre.transform.position = Vaisseau.positionRecepteur;
                    membre.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                }
            }

            else if (!collision.gameObject.GetComponentInParent<MembreEquipage>().ennemi && collision.GetComponentInParent<MembreEquipage>() is Clone)
            {
                Vaisseau = GameObject.Find("Vaisseau").GetComponent<Vaisseau>();
                vaisseauEnnemi = GameObject.Find("VaisseauEnnemi").GetComponent<Vaisseau>();

                if (Vaisseau.possedeTeleporteur)
                {
                    Sol sol = vaisseauEnnemi.GetRandomAvailableTile();
                    Transform membre = collision.gameObject.transform.parent;
                    Debug.Log("je teleporte des clones");
                    membre.transform.position = sol.transform.position;
                    membre.gameObject.transform.GetChild(0).gameObject.SetActive(false);

                    //collision.GetComponentInParent<MembreEquipage>().etat = MembreEquipage.EnumEquipages.eAction;
                    collision.GetComponentInParent<MembreEquipage>().etat = MembreEquipage.EnumEquipages.ePassif;
                    collision.GetComponentInParent<Clone>().ActionEquipage();
                    collision.GetComponentInParent<MembreEquipage>().cloneTeleporter = true;
                }
            }

            else if (collision.gameObject.GetComponentInParent<MembreEquipage>().ennemi)
            {

            }
        }
    }
}
