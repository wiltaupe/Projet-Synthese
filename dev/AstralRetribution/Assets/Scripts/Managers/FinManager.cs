using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Venger()
    {
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        Destroy(GameObject.Find("Vaisseau"));
    }
}
