using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporteur : Module
{
    public override Etat Type { get; set; } = Etat.passif;
    public override bool teleporteur { get; set; } = true;
    Vaisseau vaisseau;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Equipage")
        {
            if (!collision.gameObject.GetComponentInParent<MembreEquipage>().ennemi)
            {
                vaisseau = GameObject.Find("Vaisseau").GetComponent<Vaisseau>();

                if (vaisseau.possedeTeleporteurRecepteur)
                {
                    Transform membre = collision.gameObject.transform.parent;
                    Debug.Log("je teleporte");
                    Debug.Log(vaisseau.positionRecepteur);
                    membre.transform.position = vaisseau.positionRecepteur;
                    membre.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                }
            }

            if (collision.gameObject.GetComponentInParent<MembreEquipage>().ennemi)
            {

            }
        }
    }
}
