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

    GameObject grid, vaisseau, pos1;
    public void Start()
    {
        vaisseau = GameObject.Find("VaisseauJoueur");
        pos1 = GameObject.Find("Canvas/ContientIterationPlanete/Circle1");
        background.sprite = MainManager.Instance.Background;

        vaisseau.transform.localScale = new Vector3((Screen.width / 1920) * 0.705f, (Screen.height / 1080) * 0.705f, 0);
        vaisseau.transform.position = positionVaisseau.position;

        if (PlaneteManager.Instance.position == 1)
        {
            var _spriteRender = pos1.GetComponent<SpriteRenderer>();
            _spriteRender.color = new Color(236, 104, 104);
        }

        if (PlaneteManager.Instance.fait == false)
        {
            Generation();
            PlaneteManager.Instance.fait = true;
        }

        else
        {
            PlaneteManager.Instance.PlacerActif();
        }

    }

    public void Generation()
    {
        PlaneteManager.Instance.position = 1;
        PlaneteManager.Instance.GenererPlanetes(200);
        PlaneteManager.Instance.PlacerActif();
    }

}
