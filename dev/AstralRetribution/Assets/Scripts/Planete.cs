using UnityEngine;

public class Planete : MonoBehaviour
{
    GameObject cercle;

    void Start()
    {
        cercle = transform.GetChild(0).gameObject;
        animation();
    }

    private void OnMouseEnter()
    {
        Debug.Log(cercle.transform.position);
        Debug.Log(VerificationPosition(cercle));
        cercle.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnMouseExit()
    {
        cercle.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void animation()
    {
        //AnimationState tempslancement = cercle.GetComponent<AnimationState>();
        //float tempsTotal = tempslancement.length;
        //float nouveauTemps = UnityEngine.Random.Range(0, tempsTotal);

        //tempslancement.time = nouveauTemps;
    }

    public int VerificationPosition(GameObject planete)
    {
        int position = 11;

        for (double i = (planete.transform.position.x + 55); i < 455; i += 45.5)
        {
            position -= 1;
        }

        return position;
    }
}