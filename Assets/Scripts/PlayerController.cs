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

    public ParticleSystem ptclDamage;

    //Animators
    public Animator anmPlayer, anmEngineBack, anmEngineBottom1, anmEngineBottom2;

    [Range(0f, 1f)]
    public float timeSlowdown;
    public TeleporterController teleportController;

    //UI
    public Image imgEnergy;

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

            imgEnergy.fillAmount = Mathf.Min(energy / maxEnergy, 1f);

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

            if (Input.GetAxis(Buttons.Move_Horizontal) > 0)
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

            if (Input.GetAxis(Buttons.Move_Horizontal) > 0)
            {
                //float AngleRad = Mathf.Atan2(Input.GetAxis(Buttons.Move_Vertical), Input.GetAxis(Buttons.Move_Horizontal));
                //float AngleDeg = (180 / Mathf.PI) * AngleRad;
                //engineAxis.transform.rotation = Quaternion.Lerp(engineAxis.transform.rotation, Quaternion.Euler(0, 0, AngleDeg), Time.deltaTime * 10f);

                anmEngineBack.SetBool("BurningBack", true);
            }
            else
            {
                anmEngineBack.SetBool("BurningBack", false);
            }

            if (Input.GetAxis(Buttons.Move_Vertical) > 0)
            {
                anmEngineBottom1.SetBool("BurningBack", true);
                anmEngineBottom2.SetBool("BurningBack", true);
            }
            else
            {
                anmEngineBottom1.SetBool("BurningBack", false);
                anmEngineBottom2.SetBool("BurningBack", false);
            }
        }
        else
        {
            if (Input.GetButtonUp(Buttons.Teleport))
            {
                anmEngineBack.SetBool("BurningBack", false);
                anmEngineBottom1.SetBool("BurningBack", false);
                anmEngineBottom2.SetBool("BurningBack", false);
                anmPlayer.SetTrigger("Teleport");
                teleportController.Deactivate();
                Time.timeScale = 1f;
            }
        }
    }

    public void EndTeleport()
    {
        isTeleporting = false;
        transform.position = teleportController.transform.position;
        cGravity.freezeMovement = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tags.Obstacle)
        {
            energy -= damageEnergyConsumption;
            Destroy(other.gameObject);
            //TODO - Damage Effects

            CameraShake.instance.RequestShake(1f, .5f, true);
            ptclDamage.Play();
        }
        else if (other.tag == Tags.EnergyPack)
        {
            energy += energyPackGain;

            energy = Mathf.Min(energy, maxEnergy);

            Destroy(other.gameObject);
            //TODO - Energy Effects
        }
    }
}
