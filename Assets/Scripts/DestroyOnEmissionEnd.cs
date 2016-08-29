using UnityEngine;
using System.Collections;

public class DestroyOnEmissionEnd : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, GetComponent<ParticleSystem>().duration);
    }
}
