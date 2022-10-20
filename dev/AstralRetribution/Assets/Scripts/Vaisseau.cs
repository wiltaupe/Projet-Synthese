using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Vaisseau : MonoBehaviour
{
    public List<RectInt> Salles { get; set; }
    [SerializeField] private int taille;
    [SerializeField] private int nbIterations;
    // Start is called before the first frame update

    private void Start()
    {
        Salles = MainManager.Instance.RoomManager.GenererSalles(taille, nbIterations);
        MainManager.Instance.GridManager.AfficherSalles(Salles,taille);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
