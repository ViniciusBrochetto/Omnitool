using UnityEngine;
using System.Collections;

public class ObjectMover : MonoBehaviour
{
    public MovementType movementType;
    public float speed;

    void Start()
    {
        switch (movementType)
        {
            case MovementType.straight:
                StartCoroutine(MovementStraight());
                break;
            case MovementType.sin:
                break;
            default:
                break;
        }
    }

    private IEnumerator MovementStraight()
    {
        while (true)
        {
            if (GameController.instance.gameState == GameState.Playing)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
