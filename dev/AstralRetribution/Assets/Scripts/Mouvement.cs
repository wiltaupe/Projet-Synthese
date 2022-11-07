using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    private Animator anim;
    private Vector2 direction, lastDirection = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetFloat("Horizontal", direction.x);
        anim.SetFloat("Vertical", direction.y);
        anim.SetFloat("Vitesse", direction.sqrMagnitude);


        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");


        if (direction.sqrMagnitude > 0.1f)
        {
            anim.SetFloat("LastH",direction.x);
            anim.SetFloat("LastV", direction.y);
        }


        direction.Normalize();

    }
}
