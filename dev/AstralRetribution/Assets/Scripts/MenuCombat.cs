using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCombat : MonoBehaviour
{
    [SerializeField] private Transform posJoueur, posEnnemi;
    [SerializeField] private Vaisseau vaisseauEnnemi;
    // Start is called before the first frame update
    void Start()
    {
       GameObject.Find("Vaisseau").transform.position = posJoueur.position;
       Instantiate(vaisseauEnnemi.gameObject, posEnnemi.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RetourHub()
    {
        SceneManager.LoadSceneAsync("MenuHub");
    }
}
