using UnityEngine;
using System.Collections;

public class levelColorSwitcher : MonoBehaviour
{
    public Color[] lv1_Colors;
    public Color[] lv2_Colors;
    public Color[] lv3_Colors;
    public Color[] lv4_Colors;
    public Color[] lv5_Colors;

    private Color[] lvCurr_Colors;
    private int index;
    private Camera cam;

    public float switchTime;

    void Start()
    {
        switch (GameController.instance.levelSelected)
        {
            case 1:
                lvCurr_Colors = lv1_Colors;
                break;
            case 2:
                lvCurr_Colors = lv2_Colors;
                break;
            case 3:
                lvCurr_Colors = lv3_Colors;
                break;
            case 4:
                lvCurr_Colors = lv4_Colors;
                break;
            case 5:
                lvCurr_Colors = lv5_Colors;
                break;
            default:
                lvCurr_Colors = lv1_Colors;
                break;
        }

        cam = GetComponent<Camera>();
        index = Random.Range(0, lvCurr_Colors.Length);
        cam.backgroundColor = lvCurr_Colors[index];

        StartCoroutine(SwitchColor());
    }


    IEnumerator SwitchColor()
    {
        while (true)
        {
            int aux;

            do
                aux = Random.Range(0, lvCurr_Colors.Length);
            while (aux == index);

            index = aux;

            float t = 0f;
            float tEnd = Random.Range(4f, 6f);
            Color originalC = cam.backgroundColor;

            while (t <= tEnd)
            {
                t += Time.deltaTime;
                cam.backgroundColor = Color.Lerp(originalC, lvCurr_Colors[index], t / tEnd);

                yield return new WaitForSeconds(Time.deltaTime);
            }

            yield return new WaitForSeconds(switchTime);
        }
    }
}
