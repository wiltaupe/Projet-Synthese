using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloneur : Module
{
    public override Etat Type { get; set; } = Etat.actif;
    public override bool Cloning { get; set; } = true;

    public GameObject Clone;
    private float accumulateurTemps = 0.0f;
    public float tempsdistance = 10.0f;
    public int compteurClone = 0; 


    private void FixedUpdate()
    {
        accumulateurTemps += Time.fixedDeltaTime;

        if (Ennemi)
        {
            if (vaisseauEnnemi != null)
            {
                if (/*vaisseauEnnemi.possedeCloneur && */accumulateurTemps > tempsdistance && Type == Etat.actif && compteurClone < 4)
                {

                    Transform MembreClone = Instantiate(Clone, transform.position, Quaternion.identity).transform;
                    Physics2D.IgnoreCollision(MembreClone.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
                    vaisseauEnnemi.MembresEquipage.Add(MembreClone.gameObject);
                    vaisseauEnnemi.MembreClone.Add(MembreClone.gameObject);
                    MembreClone.GetComponent<MembreEquipage>().tuile = currentTile;
                    MembreClone.GetComponent<MembreEquipage>().MaxVie = 10;
                    MembreClone.GetComponent<Clone>().cloneur = this;
                    MembreClone.gameObject.transform.SetParent(currentTile.transform);

                    float ajuster = 10 / (float)ShipManager.Taille;
                    MembreClone.localScale = new Vector3(ajuster, ajuster, 0);
                    compteurClone += 1;

                    accumulateurTemps = 0.0f;
                    float ratio = (Time.time + 5.0f) / 5.0f;
                }
            }
        }

        else
        {
            if (Vaisseau != null)
            {
                if (Vaisseau.possedeCloneur && accumulateurTemps > tempsdistance && Type == Etat.actif && compteurClone < 4)
                {

                    Transform MembreClone = Instantiate(Clone, transform.position, Quaternion.identity).transform;
                    Physics2D.IgnoreCollision(MembreClone.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
                    Vaisseau.MembresEquipage.Add(MembreClone.gameObject);
                    Vaisseau.MembreClone.Add(MembreClone.gameObject);

                    if (Vaisseau != null)
                    {
                        MembreClone.GetComponent<MembreEquipage>().vaisseau = Vaisseau;
                        MembreClone.GetComponent<MembreEquipage>().ennemi = false;
                    }
                    else
                    {
                        MembreClone.GetComponent<MembreEquipage>().vaisseau = vaisseauEnnemi;
                        MembreClone.GetComponent<MembreEquipage>().ennemi = true;
                    }

                    MembreClone.GetComponent<MembreEquipage>().tuile = currentTile;
                    MembreClone.GetComponent<MembreEquipage>().MaxVie = 10;
                    MembreClone.GetComponent<Clone>().cloneur = this;
                    MembreClone.gameObject.transform.SetParent(currentTile.transform);

                    float ajuster = 14 / (float)ShipManager.Taille;
                    MembreClone.localScale = new Vector3(ajuster, ajuster, 0);
                    compteurClone += 1;

                    accumulateurTemps = 0.0f;
                    float ratio = (Time.time + 5.0f) / 5.0f;
                }
            }
        }
    }
}
