using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    public float speedMin;
    public float speedMax;
    public bool randomDir;

    float speed;

    void Start()
    {
        speed = Random.Range(speedMin, speedMax);

        if (randomDir)
            speed = Random.value > 0.5f ? -speed : speed;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}
