using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSelection : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite[] textures;
    [SerializeField] private Transform positionJoueur;
    // Start is called before the first frame update
    void Start()
    {
        
        GenererMembreEquipage(GenererVaisseauJoueur());
        GenererBackground();
        
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
