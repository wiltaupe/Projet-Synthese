using UnityEngine;
using UnityEngine.SceneManagement;

public class Planete : MonoBehaviour
{
    public Evenement evenementEvent;
    public GameObject cercle;
    public int pos;
    public bool possedeCheminDevant = false;
    public bool possedeCheminDerriere = false;
    public Planete monEvenement;

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
            //SceneManager.LoadScene("MenuCombat");
            /*}
            else
            {*/
            PlaneteManager.Instance.currentEvent = EnvoyerEvent();
            SceneManager.LoadScene("MenuEvenement");

            /*}*/


            
        }
    }

    public virtual Planete EnvoyerEvent()
    {
        throw new System.NotImplementedException();
    }

    private void OnMouseOver()
    {
        if (PlaneteManager.Instance.VerificationPosition(transform.position.x) > PlaneteManager.Instance.GetPosition() || (PlaneteManager.Instance.GetPosition() == 1 && PlaneteManager.Instance.VerificationPosition(transform.position.x) == PlaneteManager.Instance.GetPosition() && !PlaneteManager.Instance.GetDebut()))
        {

            cercle.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        cercle.SetActive(false);
    }
}