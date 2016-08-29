using UnityEngine;
using System.Collections;

public class ObjectMover : MonoBehaviour
{
    public ObjMoverParams objMoverParams;

    public Transform pos; 

    void Start()
    {
        switch (objMoverParams.movementType)
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
                pos.parent = transform.parent;
                pos.position = transform.position;
                transform.Translate(transform.right * objMoverParams.ORB_radius);
                break;
            default:
                StartCoroutine(MovementStraight());
                break;
        }
    }

    void Update()
    {
        if (objMoverParams.movementType == MovementType.orbit)
        {
            transform.RotateAround(pos.position, Vector3.forward, objMoverParams.ORB_speed * Time.deltaTime);
        }
    }

    private IEnumerator MovementStraight()
    {
        while (true)
        {
            if (GameController.instance.gameState == GameState.Playing)
            {
                transform.Translate(Vector2.left * objMoverParams.STR_speed * Time.deltaTime);
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
                float y = Mathf.Sin(t * objMoverParams.SIN_frequency) * objMoverParams.SIN_amplitude / 2f;
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
                float x = Mathf.Sin(t * objMoverParams.SIN_frequency) * objMoverParams.SIN_amplitude / 2f;
                transform.localPosition = pos + new Vector2(x, 0f);

                t += Time.deltaTime;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
