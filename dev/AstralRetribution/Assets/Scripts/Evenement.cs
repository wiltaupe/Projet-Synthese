using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "evenements", menuName = "event")]
public class Evenement : ScriptableObject
{
    public string[] description;
    public Sprite[] background;
    public bool[] choix;
    public bool[] combat;
    public bool[] hub;
    public bool[] vaisseauImportant;
    public GameObject[] modulePossible;
}