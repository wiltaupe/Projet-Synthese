using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCombat : MonoBehaviour
{
    [SerializeField] private Transform posJoueur,posEnnemi;
    private GameObject vaisseauJoueur, vaisseauEnnemi;
    
    // Start is called before the first frame update

    private void Awake()
    {

    }
    
    void Start()
    {
        init_vaisseaux();



        
    }

    private void init_vaisseaux()
    {
        vaisseauJoueur = GameObject.Find("Vaisseau");
        vaisseauJoueur.transform.position = posJoueur.position;
        vaisseauJoueur.transform.localScale = new Vector2(1.05f, 1.05f);



        vaisseauEnnemi = MainManager.Instance.ShipManager.GenererVaisseau(posEnnemi.position, true).gameObject;
        vaisseauEnnemi.transform.localScale = new Vector2(1.05f, 1.05f);
    }

    void Update()
    {

    }

    public void RetourHub()
    {
        SceneManager.LoadSceneAsync("MenuHub");
    }
}
