using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MembreEquipage
{
    public Cloneur cloneur;
    public override void MembreMort()
    {
        cloneur.compteurClone = cloneur.compteurClone - 1;
        Destroy(this.gameObject);
    }
}
