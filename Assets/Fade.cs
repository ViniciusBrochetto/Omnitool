using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public float time;
    public Image imgToFade;

    private Color c1, c2;

    void Start()
    {
        imgToFade.enabled = true;
        c1 = imgToFade.color;
        c2 = c1;
        c2.a = 0f;

        StartCoroutine(FadeRot());
    }

    IEnumerator FadeRot()
    {
        float t = 0f;

        while (t < time)
        {
            imgToFade.color = Color.Lerp(c1, c2, t / time);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);

        yield return null;
    }
}
