using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //privates
    private bool isAlive;
    private bool isTeleporting;
    private CustomGravity cGravity;

    //publics
    public float hSpeed;
    public float vSpeed;

    public float energy = 100f;
    public float maxEnergy = 200f;
    public float energyConsumption;
    public float teleportEnergyConsumption;
    public float damageEnergyConsumption;
    public float energyPackGain;

    [Range(0f,1f)]
    public float timeSlowdown;
    public TeleporterController teleportController;

    //UI
    public Slider sldEnergy;

    void Start()
    {
        isAlive = true;
        cGravity = GetComponent<CustomGravity>();
    }

    void Update()
    {
        if (GameController.instance.gameState == GameState.Playing)
        {
            energy -= energyConsumption * (Time.deltaTime / Time.timeScale);

            if (isTeleporting)
                energy -= teleportEnergyConsumption * (Time.deltaTime / Time.timeScale);


            if (energy <= 0)
            {
                //TODO -- ENDGAME
            }

            sldEnergy.value = Mathf.Min(energy / maxEnergy, 1f);

            InputHandler();
        }
    }

    private void InputHandler()
    {
        if (!isTeleporting)
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

            if (Input.GetButtonDown(Buttons.Teleport))
            {
                Time.timeScale = 1f * timeSlowdown;
                teleportController.Activate();
                teleportController.transform.position = this.transform.position;
                isTeleporting = true;
                cGravity.freezeMovement = true;

            }
            else
            {
                cGravity.AddForce(move.x, move.y);
            }
        }
        else
        {
            if (Input.GetButtonUp(Buttons.Teleport))
            {
                Time.timeScale = 1f;
                transform.position = teleportController.transform.position;
                teleportController.Deactivate();
                isTeleporting = false;
                cGravity.freezeMovement = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tags.Obstacle)
        {
            energy -= damageEnergyConsumption;
            Destroy(other.gameObject);
            //TODO - Damage Effects
        }
        else if (other.tag == Tags.EnergyPack)
        {
            energy += energyPackGain;
            Destroy(other.gameObject);
            //TODO - Energy Effects
        }
    }
}
