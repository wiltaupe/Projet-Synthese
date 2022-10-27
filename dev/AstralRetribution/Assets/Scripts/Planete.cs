using UnityEngine;
using UnityEngine.SceneManagement;

public class Planete : MonoBehaviour
{
    GameObject cercle;
    public int pos;
    public bool possedeCheminDevant = false;
    public bool possedeCheminDerriere = false;

    void Start()
    {
        cercle = transform.GetChild(0).gameObject;
        //VerificationPosition();
    }

    public void OnMouseDown()
    {
        PlaneteManager.Instance.SetPosition(VerificationPosition());
        SceneManager.LoadScene("MenuCombat");
    }

    private void OnMouseEnter()
    {
        cercle.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnMouseExit()
    {
        cercle.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void Anim()
    {
        //AnimationState tempslancement = cercle.GetComponent<AnimationState>();
        //float tempsTotal = tempslancement.length;
        //float nouveauTemps = UnityEngine.Random.Range(0, tempsTotal);

        //tempslancement.time = nouveauTemps;
        return;
    }

    public int VerificationPosition()
    {
        int position = 11;

        for (double i = (transform.position.x + 55); i < 455; i += 45.5)
        {
            position -= 1;
        }

        return position;
    }
}