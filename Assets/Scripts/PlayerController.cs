using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    //privates
    private bool isAlive;
    private CustomGravity cGravity;

    //publics
    public float hSpeed;
    public float vSpeed;

    void Start()
    {
        isAlive = true;
        cGravity = GetComponent<CustomGravity>();
    }

    void FixedUpdate()
    {
        InputHandler();
    }

    void LateUpdate()
    {
        MoveHandler();
    }

    private void InputHandler()
    {
        Vector2 move = Vector2.zero;

        if (Input.GetButton(Buttons.Move_Vertical))
        {
            float v = Input.GetAxis(Buttons.Move_Vertical);
            move.y = v * vSpeed * Time.deltaTime;
        }
        if (Input.GetButton(Buttons.Move_Horizontal))
        {
            float h = Input.GetAxis(Buttons.Move_Horizontal);
            move.x = h * Time.deltaTime * hSpeed;
        }

        cGravity.AddForce(move.x, move.y);
    }

    private void MoveHandler()
    {

    }
}
