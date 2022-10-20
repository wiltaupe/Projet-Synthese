using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    public GridManager GridManager { get; private set; }
    public RoomManager RoomManager { get; private set; }
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
    }
}
