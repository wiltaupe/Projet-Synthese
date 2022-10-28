using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCombat : MonoBehaviour
{
    [SerializeField] private Transform posJoueur,posEnnemi;
    // Start is called before the first frame update

    private void Awake()
    {
        //GameObject.Find("VaisseauJoueur").transform.position = GameObject.Find("PosJoueur").transform.position;
        //Instantiate(vaisseauEnnemi, GameObject.Find("PosEnnemi").transform.position, Quaternion.identity);
    }
    
    void Start()
    {
            //Debug.Log(vaisseauEnnemi);

            GameObject.Find("Vaisseau").transform.position = posJoueur.position;
            MainManager.Instance.ShipManager.GenererVaisseau(posEnnemi.position);

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
