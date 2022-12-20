using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSelection : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite[] textures;
    [SerializeField] private Transform positionJoueur;
    public GameObject boutonMenu;
    Vaisseau vaisseaujoueur;

    void Start()
    {
        vaisseaujoueur = GenererVaisseauJoueur();
        GenererMembreEquipage(vaisseaujoueur);
        GenererBackground();
        boutonMenu.SetActive(false);
    }

    private void Update()
    {
        if (vaisseaujoueur.ModulesActifs.Count == 3)
        {
            boutonMenu.SetActive(true);
        }
    }

    private Vaisseau GenererVaisseauJoueur()
    {
        return MainManager.Instance.ShipManager.GenererVaisseau(positionJoueur.position,false);
    }

    private void GenererMembreEquipage(Vaisseau vaisseau)
    {
        MainManager.Instance.MemberManager.GenererMembres(10,vaisseau,false);
    }

    private void GenererBackground()
    {
        int randomInt = UnityEngine.Random.Range(0, textures.Length);
        image.sprite = textures[randomInt];
        MainManager.Instance.Background = image.sprite;
    }

    public void TerminerMiseEnPlace()
    {
        SceneManager.LoadSceneAsync("MenuHub");
    }
}
