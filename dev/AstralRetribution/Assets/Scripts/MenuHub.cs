using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MenuHub : MonoBehaviour
{
    public TileBase gridtile;
    public Transform positionVaisseau;
    public Image background;
    public int posiVaisseau;

    GameObject grid, vaisseau, pos1;
    // Start is called before the first frame update
    public void Start()
    {
        vaisseau = GameObject.Find("Vaisseau");
        pos1 = GameObject.Find("Canvas/ContientIterationPlanete/Circle1");
        background.sprite = MainManager.Instance.Background;



        vaisseau.transform.localScale = new Vector3((Screen.width / 1920) * 0.705f, (Screen.height / 1080) * 0.705f, 0);
        vaisseau.transform.position = positionVaisseau.position;

        //MainManager.Instance.PlaneteManager.GenererPlanetes(40);
        MainManager.Instance.PlaneteManager.GenererPlanetes(200);
        posiVaisseau = MainManager.Instance.PlaneteManager.GetPosition();
        MainManager.Instance.PlaneteManager.GenererPathPlanete();

    }

    // Update is called once per frame
    public void Combat()
    {
        SceneManager.LoadScene("MenuCombat");
    }
}
