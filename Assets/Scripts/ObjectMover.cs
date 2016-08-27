using UnityEngine;
using System.Collections;

public class ObjectMover : MonoBehaviour
{
    public MovementType movementType;
    public float STR_speed;
    public float SIN_frequency;
    public float SIN_amplitude;
    public float ORB_radius;

    void Start()
    {
        switch (movementType)
        {
            case MovementType.straight:
                StartCoroutine(MovementStraight());
                break;
            case MovementType.sinV:
                StartCoroutine(MovementSinVert());
                break;
            case MovementType.sinH:
                StartCoroutine(MovemenSinHor());
                break;
            case MovementType.orbit:
                StartCoroutine(MovementOrbit());
                break;
            default:
                StartCoroutine(MovementStraight());
                break;
        }
    }

    private IEnumerator MovementStraight()
    {
        while (true)
        {
            if (GameController.instance.gameState == GameState.Playing)
            {
                transform.Translate(Vector2.left * STR_speed * Time.deltaTime);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator MovementSinVert()
    {
        float t = 45f;
        Vector2 pos = transform.localPosition;

        while (true)
        {
            if (GameController.instance.gameState == GameState.Playing)
            {
                float y = Mathf.Sin(t * SIN_frequency) * SIN_amplitude / 2f;
                transform.localPosition = pos + new Vector2(0f, y);

                t += Time.deltaTime;
            }

            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator MovemenSinHor()
    {
        float t = 45f;
        Vector2 pos = transform.localPosition;

        while (true)
        {
            if (GameController.instance.gameState == GameState.Playing)
            {
                float x = Mathf.Sin(t * SIN_frequency) * SIN_amplitude / 2f;
                transform.localPosition = pos + new Vector2(x, 0f);

                t += Time.deltaTime;
            }

            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator MovementOrbit()
    {
        float t = 45f;
        Vector2 pos = transform.localPosition;

        while (true)
        {
            if (GameController.instance.gameState == GameState.Playing)
            {
                float x = Mathf.Sin(t * SIN_frequency) * SIN_amplitude / 2f;
                transform.localPosition = pos + new Vector2(x, 0f);

                t += Time.deltaTime;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
