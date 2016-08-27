using UnityEngine;
using System.Collections;

public class TeleporterController : MonoBehaviour
{
    public float hSpeed;
    public float vSpeed;

    void Update()
    {
        MoveHandler();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void MoveHandler()
    {
        Vector2 move = Vector2.zero;
        move.y = Input.GetAxis(Buttons.Move_Vertical) * vSpeed * Time.deltaTime;
        move.x = Input.GetAxis(Buttons.Move_Horizontal) * hSpeed * Time.deltaTime;

        transform.Translate(move);
    }
}
