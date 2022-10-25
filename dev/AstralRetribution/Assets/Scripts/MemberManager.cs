using System.Collections.Generic;
using UnityEngine;

public class MemberManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> membresPossible;
    public GameObject GenererMembre(Sol sol)
    {
        


        int randomInt = Random.Range(0, membresPossible.Count);

        GameObject membre = membresPossible[randomInt];
        GameObject obj = Instantiate(membre, sol.transform.position + new Vector3(0,6), Quaternion.identity);
        obj.transform.SetParent(sol.transform);
        sol.MembreEquipage = obj;
        
        return obj;
    }


}