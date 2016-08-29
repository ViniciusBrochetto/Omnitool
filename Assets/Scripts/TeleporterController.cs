using UnityEngine;
using System.Collections;

public class TeleporterController : MonoBehaviour
{
    public float hSpeed;
    public float vSpeed;

    void LateUpdate()
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

        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position + new Vector3(move.x, move.y, 0f));

        if (viewportPos.x > 0.15f && viewportPos.x < 0.95f)
            transform.Translate(Vector3.right * move.x);

        if (viewportPos.y > 0.05f && viewportPos.y < 0.95f)
            transform.Translate(Vector3.up * move.y);

    }
}
