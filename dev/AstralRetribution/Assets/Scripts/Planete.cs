using UnityEngine;
using UnityEngine.SceneManagement;

public class Planete : MonoBehaviour
{
    protected GameObject cercle;
    public int pos;
    public bool possedeCheminDevant = false;
    public bool possedeCheminDerriere = false;
    public Evenement monEvenement;

    void Start()
    {
        cercle = transform.GetChild(0).gameObject;
    }

    public void OnMouseDown()
    {
        if (PlaneteManager.Instance.VerificationPosition(transform.position.x) > PlaneteManager.Instance.GetPosition() || (PlaneteManager.Instance.GetPosition() == 1 && PlaneteManager.Instance.VerificationPosition(transform.position.x) == PlaneteManager.Instance.GetPosition() && !PlaneteManager.Instance.GetDebut()))
        {
            PlaneteManager.Instance.SetPosition(PlaneteManager.Instance.VerificationPosition(transform.position.x));
            PlaneteManager.Instance.SetposSelection(gameObject.transform.position);
            //if (Random.Range(0, 2) == 1)
            //{
                SceneManager.LoadScene("MenuCombat");
            /*}
            else
            {
                PlaneteManager.Instance.currentEvent = EnvoyerEvent();
                SceneManager.LoadScene("MenuEvenement");

            }*/


            
        }
    }

    public virtual Evenement EnvoyerEvent()
    {
        throw new System.NotImplementedException();
    }

    public void OnMouseEnter()
    {
        if (PlaneteManager.Instance.VerificationPosition(transform.position.x) > PlaneteManager.Instance.GetPosition() || (PlaneteManager.Instance.GetPosition() == 1 && PlaneteManager.Instance.VerificationPosition(transform.position.x) == PlaneteManager.Instance.GetPosition() && !PlaneteManager.Instance.GetDebut()))
        {
            cercle.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnMouseExit()
    {
        cercle.GetComponent<SpriteRenderer>().enabled = false;
    }
}