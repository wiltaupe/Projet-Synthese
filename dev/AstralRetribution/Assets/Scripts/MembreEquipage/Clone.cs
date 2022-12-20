using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MembreEquipage
{
    public Cloneur cloneur;
    public GameObject particuleEffect;
    public override void MembreMort()
    {
        cloneur.compteurClone--;
        vaisseau.MembresEquipage.Remove(this.gameObject);
        vaisseau.MembreClone.Remove(this.gameObject);
        Instantiate(MortPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public override void ActionEquipage()
    {
        StartCoroutine(waitEquipage());
    }

    IEnumerator waitEquipage()
    {
        yield return new WaitForSeconds(1);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(1);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.25f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.25f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.10f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.10f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.10f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.10f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.10f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(1f);
        Instantiate(particuleEffect, transform.position, Quaternion.identity);
        MembreMort();
    }
}
