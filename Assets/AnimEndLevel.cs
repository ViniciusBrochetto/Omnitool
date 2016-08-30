using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimEndLevel : MonoBehaviour
{
    public GameObject player;
    public GameObject fade;
    public GameObject partsSpawner;

    public AudioSource bgAudio;
    public AudioSource bgAudioMonolith;
    public AudioSource warpOut;

    public Animator anmMonolith;
    public GameObject monolith;

    public Text txt1, txt2, txt3;

    public void StartAnimation(bool endGame)
    {
        if (endGame)
        {
            monolith = GameObject.Find("MonolithToAnimate");
            StartCoroutine(AnimationEndGame());
        }
        else
            StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        Destroy(partsSpawner);

        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<PolygonCollider2D>().enabled = false;

        Animator a = player.GetComponent<Animator>();

        float t, tEnd;

        t = 0f;
        tEnd = 1f;
        while (t <= tEnd)
        {
            bgAudio.pitch = Mathf.Lerp(1f, 0.25f, t);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }



        t = 0f;
        tEnd = 3f;
        Vector3 startScale = player.transform.localScale;
        Vector3 endScale = player.transform.localScale * 2f;
        Vector3 startPos = player.transform.position;
        Vector3 endPos = Camera.main.ViewportToWorldPoint(new Vector3(.5f, .5f, 10f));
        while (t <= tEnd)
        {
            player.transform.position = Vector3.Lerp(startPos, endPos, t);
            player.transform.localScale = Vector3.Lerp(startScale, endScale, t);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(1f);

        a.SetTrigger("Teleport");
        a.SetBool("End", true);
        fade.SetActive(true);
        warpOut.Play();

        yield return new WaitForSeconds(2f);

        if (GameController.instance.levelSelected == 5)
            GameController.instance.UploadTopScore();

        SceneManager.LoadScene(Scenes.LevelSelection);

        yield return null;
    }

    IEnumerator AnimationEndGame()
    {
        monolith.transform.parent = null;

        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<PolygonCollider2D>().enabled = false;

        Animator a = player.GetComponent<Animator>();

        float t, tEnd;

        t = 0f;
        tEnd = 1f;
        while (t <= tEnd)
        {
            bgAudio.pitch = Mathf.Lerp(1f, 0.25f, t);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }



        t = 0f;
        tEnd = 3f;
        Vector3 startPos = player.transform.position;
        Vector3 endPos = Camera.main.ViewportToWorldPoint(new Vector3(.5f, .5f, 10f));
        Vector3 mStartPos = monolith.transform.position;
        Vector3 mEndPos = Camera.main.ViewportToWorldPoint(new Vector3(.9f, .5f, 10f));
        while (t <= tEnd)
        {
            player.transform.position = Vector3.Lerp(startPos, endPos, t);
            monolith.transform.position = Vector3.Lerp(mStartPos, mEndPos, t);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(1f);

        bgAudioMonolith.Play();

        t = 0f;
        tEnd = 0.2f;
        startPos = player.transform.position;
        endPos = Camera.main.ViewportToWorldPoint(new Vector3(1f, .5f, 10f));
        while (t <= tEnd)
        {
            player.transform.position = Vector3.Lerp(startPos, endPos, t);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        a.SetTrigger("Teleport");
        a.SetBool("End", true);
        warpOut.Play();

        yield return new WaitForSeconds(0.2f);

        player.SetActive(false);

        fade.GetComponent<Fade>().time = 0.5f;
        fade.SetActive(true);

        yield return new WaitForSeconds(2f);

        anmMonolith.gameObject.SetActive(true);

        while (bgAudioMonolith.isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }

        t = 0f;
        tEnd = 1f;
        while (t <= tEnd)
        {
            bgAudio.pitch = Mathf.Lerp(0.25f, 1f, t);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }


        yield return new WaitForSeconds(1f);

        txt1.gameObject.SetActive(true);
        t = 0f;
        tEnd = 2f;
        Color c1 = Color.white;
        c1.a = 0f;
        Color c2 = Color.white;
        while (t <= tEnd)
        {
            txt1.color = Color.Lerp(c1, c2, t);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(3f);

        txt1.gameObject.SetActive(true);
        t = 0f;
        tEnd = 2f;
        while (t <= tEnd)
        {
            txt1.color = Color.Lerp(c2, c1, t);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        txt1.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        txt2.gameObject.SetActive(true);

        t = 0f;
        tEnd = 2f;
        while (t <= tEnd)
        {
            txt2.color = Color.Lerp(c1, c2, t);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(3f);

        t = 0f;
        tEnd = 2f;
        while (t <= tEnd)
        {
            txt2.color = Color.Lerp(c2, c1, t);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        txt2.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        txt3.gameObject.SetActive(true);

        t = 0f;
        tEnd = 2f;
        while (t <= tEnd)
        {
            txt3.color = Color.Lerp(c1, c2, t);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(3f);

        t = 0f;
        tEnd = 2f;
        while (t <= tEnd)
        {
            txt3.color = Color.Lerp(c2, c1, t);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        txt3.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        LevelPartSpawner.instance.spawnMonolith = false;
        GameController.instance.LoadLevel(5);


        yield return null;
    }
}
