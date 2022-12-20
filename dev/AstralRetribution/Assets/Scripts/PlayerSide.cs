using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSide : MonoBehaviour
{
    void Start()
    {
        GetComponent<Image>().sprite = MainManager.Instance.Background;
    }

    void Update()
    {
        
    }
}
