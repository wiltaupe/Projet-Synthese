using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    private Animator anim;
    private Vector2 direction = new Vector2();
    private float vitesse = 10.0f;
    private Rigidbody2D body;
    private bool verif = false;

    public enum EnumEquipages
    {
        eInactif = 1,
        ePassif = 2,
        eDeplacement = 3
    };

    public EnumEquipages etat;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        etat = EnumEquipages.ePassif;
    }

    // Update is called once per frame
    void Update()
    {
        if (deplacement())
        {
            anim.SetFloat("Horizontal", direction.x);
            anim.SetFloat("Vertical", direction.y);
            anim.SetFloat("Vitesse", direction.sqrMagnitude);

            //float vitesse = etat == EnumEquipages.eDeplacement ? vitesseChasse : vitessePatrouille;
            body.velocity = direction * vitesse;

            if (direction.sqrMagnitude > 0.1f)
            {
                anim.SetFloat("LastH", direction.x);
                anim.SetFloat("LastV", direction.y);
            }


            direction.Normalize();

            /*
             *  anim.Setfloat("Vitesse",mouvementDirection.magnitude);
             *  anim.Setfloat("Horizontal",mouvementDirection.x);
             * anim.Setfloat("Vertical",mouvementDirection.y);
             *  float vitesse = etat == EnumLamas.eChasse ? vitesseChasse : vitessePatrouille
             *  rig.velocity = mouvementDirection * vitesse;
             */

        }

        /*anim.SetFloat("Horizontal", direction.x);
        anim.SetFloat("Vertical", direction.y);
        anim.SetFloat("Vitesse", direction.sqrMagnitude);*/


        //direction.x = Input.GetAxisRaw("Horizontal");
        //direction.y = Input.GetAxisRaw("Vertical");

    }

    private bool deplacement()
    {
        // ePatrouille et eChasse
        return (etat & (EnumEquipages.eDeplacement | EnumEquipages.ePassif)) != 0;
    }


    void FixedUpdate()
    {

        if (etat == EnumEquipages.ePassif && !verif)
        {
            verif = false;
            StartCoroutine(CoroutinePassif());
            verif = true;
        }

    }

    IEnumerator CoroutinePassif()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            direction.Normalize();
            yield return new WaitForSeconds(Random.Range(1.5f, 3f));
            direction = Vector2.zero;
            yield return new WaitForSeconds(Random.Range(2.0f, 4f));
        }
    }
}
