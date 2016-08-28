using UnityEngine;
using System.Collections;

public class CustomGravity : MonoBehaviour
{
    public bool freezeMovement = false;
    public float gravityAccel = 9.8f;

    private float gravityCenter;
    public float speedV;
    public float speedH;

    void Start()
    {
        gravityCenter = Camera.main.ViewportToWorldPoint(new Vector3(0f, .5f, 0f)).y;
    }

    //void Update()
    //{
    //    gravityCenter = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f)).y;
    //}

    public void AddForce(float x, float y)
    {
        AddForce(new Vector2(x, y));
    }

    public void AddForce(Vector2 direcao)
    {
        speedV += direcao.y;
        speedH += direcao.x;
    }

    void Update()
    {
        if (!freezeMovement && GameController.instance.gameState == GameState.Playing)
        {
            Vector3 topLeft = Camera.main.ViewportToWorldPoint(new Vector3(0.15f, 0.2f, 0f));
            Vector3 topLeftMax = Camera.main.ViewportToWorldPoint(new Vector3(0.15f, 0.05f, 0f));
            Vector3 bottomRight = Camera.main.ViewportToWorldPoint(new Vector3(0.95f, 0.8f, 0f));
            Vector3 bottomRightMax = Camera.main.ViewportToWorldPoint(new Vector3(0.95f, 0.95f, 0f));

            float yPos = transform.position.y;
            float gravityDir = yPos > gravityCenter ? -1f : 1f;

            if (Mathf.Abs(yPos - gravityCenter) > 0.1f)
            {
                speedV += gravityAccel * Time.deltaTime * gravityDir;
            }

            if (transform.position.y + speedV < topLeft.y)
            {
                if (speedV < 0f)
                {
                    speedV = Mathf.Lerp(speedV, 0f, Time.deltaTime * 3f);
                }
                if (transform.position.y + speedV < topLeftMax.y)
                {
                    speedV = 0f;
                }
            }
            if (transform.position.y + speedV > bottomRight.y)
            {
                if (speedV > 0f)
                {
                    speedV = Mathf.Lerp(speedV, 0f, Time.deltaTime * 2f);
                }
                if (transform.position.y + speedV > bottomRightMax.y)
                {
                    speedV = 0f;
                }
            }

            speedH = Mathf.Lerp(speedH, -0.05f, Time.deltaTime * 2f);

            if (transform.position.x + speedH > bottomRight.x || transform.position.x + speedH < topLeft.x)
                speedH = 0f;


            transform.Translate(new Vector3(speedH, speedV, 0f));

            speedV = Mathf.Lerp(speedV, 0f, Time.deltaTime * 0.3f);
            speedH = Mathf.Lerp(speedH, 0f, Time.deltaTime);
        }
    }
}
