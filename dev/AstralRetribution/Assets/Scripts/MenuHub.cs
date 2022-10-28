using System.Collections.Generic;
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
    public Dictionary<int, (GameObject, int)> actif = new();

    GameObject grid, vaisseau;
    public List<GameObject> cercle;
    public void Start()
    {
        vaisseau = GameObject.Find("Vaisseau");
        //pos1 = GameObject.Find("Canvas/ContientIterationPlanete/Circle1");
        background.sprite = MainManager.Instance.Background;

        //GameObject c = Instantiate(selection, actif[i].vecteurPosition, Quaternion.identity);

        vaisseau.transform.localScale = new Vector3((Screen.width / 1920) * 0.705f, (Screen.height / 1080) * 0.705f, 0);
        vaisseau.transform.position = positionVaisseau.position;

        /*if (PlaneteManager.Instance.position == 1)
        {
            var _spriteRender = pos1.GetComponent<SpriteRenderer>();
            _spriteRender.color = new Color(236, 104, 104);
        }*/

        if (PlaneteManager.Instance.fait == false)
        {
            Generation();
            PlaneteManager.Instance.fait = true;
        }

        else
        {
            PlaneteManager.Instance.PlacerActif();
        }

        for (int i = 0; i < cercle.Count; i++)
        {
            GameObject pos = cercle[i];
            var _spriteRender = pos.GetComponent<SpriteRenderer>();

            if (i >= PlaneteManager.Instance.position)
            {
                _spriteRender.color = new Color(255, 0, 0);
            }
            else
            {
                _spriteRender.color = new Color(0, 255, 0);
            }
        }

    }

    public void Generation()
    {
        PlaneteManager.Instance.position = 1;
        PlaneteManager.Instance.GenererPlanetes(200);
        PlaneteManager.Instance.PlacerActif();
    }

}
