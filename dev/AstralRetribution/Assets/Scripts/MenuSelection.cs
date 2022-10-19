using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MenuSelection : MonoBehaviour
{
    public Image image;
    public Sprite[] textures;
    public Tilemap tilemap;
    public TileBase sol, mur;
    // Start is called before the first frame update
    void Start()
    {
        GenererBackground();
    }
    private void GenererBackground()
    {
        int randomInt = UnityEngine.Random.Range(0, textures.Length);
        image.sprite = textures[randomInt];
    }

    public void TerminerMiseEnPlace()
    {
        SceneManager.LoadSceneAsync("MenuHub");
    }
}
