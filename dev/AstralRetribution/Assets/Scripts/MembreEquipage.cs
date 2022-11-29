using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MembreEquipage : MonoBehaviour
{


    public enum EnumEquipages
    { 
        eInactif = 1,
        ePassif = 2,
        eDeplacement =3
    };

    public EnumEquipages etat;

    // if etat du membre déquipage est passif
    private bool deplacementOuPassif()
    {
        return etat != EnumEquipages.eInactif;
    }

    private bool deplacement()
    {
        // ePatrouille et eChasse
        return (etat & (EnumEquipages.eInactif | EnumEquipages.ePassif)) != 0;
    }

    void Update()
    {
        if (deplacement())
        {
            /*
             *  anim.Setfloat("Vitesse",mouvementDirection.magnitude);
             *  anim.Setfloat("Horizontal",mouvementDirection.x);
             * anim.Setfloat("Vertical",mouvementDirection.y);
             *  float vitesse = etat == EnumLamas.eChasse ? vitesseChasse : vitessePatrouille
             *  rig.velocity = mouvementDirection * vitesse;
             */


        }

    }

    void FixedUpdate()
    {
        if (etat == EnumEquipages.ePassif)
        {
            StartCoroutine(CoroutinePassif());
        }
    }

    IEnumerator CoroutinePassif()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            // mouvementDirection = new Vector2(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f))
            // mouvementDirection.Normalize();
            yield return new WaitForSeconds(Random.Range(1.5f,3.0f));
            // mouvementDirection = Vector2.zero
            yield return new WaitForSeconds(Random.Range(2.0f, 4.0f));
        }
    
    }
}