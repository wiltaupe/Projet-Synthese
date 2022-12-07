using UnityEngine;
using UnityEngine.Events;

public class SliderScript : MonoBehaviour
{
    public int tourMax = 100;
    public float tour = 0;
    public RectTransform bar;
    public bool PlayerTurn { get; set; }
    [SerializeField] private UnityEvent tourFini;



    private void Start()
    {
        PlayerTurn = false;
        if (tourFini == null)
            tourFini = new UnityEvent();
    }

    void Update()
    {
        if (PlayerTurn)
        {
            if (tour < tourMax)
            {
                tour += Time.deltaTime;

            }
            else
            {
                PlayerTurn = false;
                tourFini.Invoke();
                return;
            }

            if (tour == 0)
            {
                bar.localScale = new Vector3(0,1, bar.localScale.z);
                
            }
            else
            {
                bar.localScale = new Vector3(tour / tourMax, 1, bar.transform.localScale.z);
            }
        }
        else
        {
            bar.transform.localScale = Vector2.zero;
        }

        
    }


}
