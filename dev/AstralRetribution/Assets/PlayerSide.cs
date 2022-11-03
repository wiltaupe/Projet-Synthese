using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = MainManager.Instance.Background;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
