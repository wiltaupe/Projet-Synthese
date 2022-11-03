using UnityEngine;

public class SliderScript : MonoBehaviour
{
    public int tourMax = 200;
    public float tour = 0;
    public RectTransform bar;


    void Update()
    {

        if (tour < tourMax)
        {
            tour += Time.deltaTime;

        }
        else tour = 0.001f;

        if (tour == 0)
        {
            bar.transform.localScale = Vector2.zero;
        }
        else
        {
            bar.localScale = new Vector3(tour / tourMax, bar.transform.localScale.y, bar.transform.localScale.z);
        }
    }


}
