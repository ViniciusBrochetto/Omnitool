using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AnimEndLevel : MonoBehaviour
{
    public GameObject player;
    public GameObject fade;
    public GameObject partsSpawner;

    public AudioSource bgAudio;
    public AudioSource warpOut;

    public void StartAnimation()
    {
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

        SceneManager.LoadScene(Scenes.LevelSelection);

        yield return null;
    }
}
