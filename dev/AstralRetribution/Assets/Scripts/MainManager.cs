using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }

    public ShipManager ShipManager { get; private set; }

    public MemberManager MemberManager { get; private set; }
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
        DontDestroyOnLoad(this);

        ShipManager = GetComponentInChildren<ShipManager>();
        MemberManager = GetComponentInChildren<MemberManager>();
    }
}
