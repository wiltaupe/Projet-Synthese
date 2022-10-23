using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    public GridManager GridManager { get; private set; }
    public RoomManager RoomManager { get; private set; }
    public PlaneteManager PlaneteManager { get; private set; }
    public Sprite Background { get; set; }

    public Vaisseau VaisseauJoueur { get; set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        GridManager = GetComponentInChildren<GridManager>();
        RoomManager = GetComponentInChildren<RoomManager>();
        PlaneteManager = GetComponentInChildren<PlaneteManager>();
    }
}
