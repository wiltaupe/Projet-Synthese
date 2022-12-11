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
        background.sprite = MainManager.Instance.Background;

        vaisseau.transform.localScale = new Vector3((Screen.width / 1920) * 2.75f, (Screen.height / 1080) * 2.75f, 0);
        vaisseau.transform.position = positionVaisseau.position;

        if (PlaneteManager.Instance.GetFait() == false)
        {
            Generation();
            PlaneteManager.Instance.SetFait(true);
        }

        else
        {
            PlaneteManager.Instance.PlacerActif();
        }

        for (int i = 0; i < cercle.Count; i++)
        {
            GameObject pos = cercle[i];
            var _spriteRender = pos.GetComponent<Image>();

            if (i >= PlaneteManager.Instance.GetPosition())
            {
                _spriteRender.color = new Color(255, 255, 255);
            }
            else
            {
                _spriteRender.color = new Color(0, 255, 0);
            }
        }

    }

    public void Generation()
    {
        PlaneteManager.Instance.SetPosition(1);
        PlaneteManager.Instance.GenererPlanetes(200);
        PlaneteManager.Instance.PlacerActif();
    }

}
