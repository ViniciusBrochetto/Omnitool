using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public float time;
    public Image imgToFade;

    public bool from;

    private Color c1, c2;

    void Start()
    {
        imgToFade.enabled = true;

        c1 = imgToFade.color;
        c2 = c1;
        c2.a = from ? 0f : 1f;


        if (from)
            StartCoroutine(FadeRot());
        else
            StartCoroutine(FadeToRot());

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

    IEnumerator FadeToRot()
    {
        float t = 0f;

        while (t < time)
        {
            imgToFade.color = Color.Lerp(c1, c2, t / time);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
        FindObjectOfType<LevelSelectionController>().LoadLevel(GameController.instance.levelSelected);

        yield return null;
    }
}
