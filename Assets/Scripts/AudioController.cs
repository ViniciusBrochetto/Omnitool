using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    //Audios Player
    public AudioSource audioCrash;
    public AudioSource audioCrash2;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayOnce()
    {

    }
}
