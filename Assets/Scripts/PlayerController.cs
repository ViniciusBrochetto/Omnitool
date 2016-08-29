using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //privates
    private bool isAccelerating;
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
    public float knowlegeGain;

    public AudioSource audioCrash1;
    public AudioSource audioCrash2;
    public AudioSource audioWarp;
    public AudioSource audioBG;
    public AudioSource audioEngines;

    public ParticleSystem ptclDamage;
    public GameObject ptclRocks;

    //Animators
    public Animator anmPlayer, anmEngineBack, anmEngineBottom1, anmEngineBottom2;

    [Range(0f, 1f)]
    public float timeSlowdown;
    public TeleporterController teleportController;

    //UI
    public Image imgEnergy;
    public Image imgKnowledge;

    void Start()
    {
        isAccelerating = true;
        cGravity = GetComponent<CustomGravity>();

        ptclDamage.randomSeed = 0;
    }

    void Update()
    {
        if (GameController.instance.gameState == GameState.Playing)
        {
            imgEnergy.fillAmount = Mathf.Min(energy / maxEnergy, 1f);
            imgKnowledge.fillAmount = Mathf.Min((GameController.instance.playerKnowledge - GameController.instance.pastLevelsNeededKnowledge) / (GameController.instance.currentLevelKnowledgeNeed - GameController.instance.pastLevelsNeededKnowledge), 1f);


            if (energy <= 0 || GameController.instance.playerKnowledge >= GameController.instance.currentLevelKnowledgeNeed)
            {
                cGravity.enabled = false;
                FindObjectOfType<AnimEndLevel>().StartAnimation();

                anmEngineBack.SetBool("BurningBack", true);
                anmEngineBottom1.SetBool("BurningBack", true);
                anmEngineBottom2.SetBool("BurningBack", true);

                audioEngines.volume = 0.25f;

                return;
            }

            energy -= energyConsumption * (Time.deltaTime / Time.timeScale);

            if (isTeleporting)
                energy -= teleportEnergyConsumption * (Time.deltaTime / Time.timeScale);

            InputHandler();


            if (isTeleporting)
            {
                audioBG.pitch = Mathf.Lerp(audioBG.pitch, 0.25f, Time.deltaTime * 10f);
                audioEngines.pitch = Mathf.Lerp(audioEngines.pitch, 0.25f, Time.deltaTime * 10f);
            }
            else
            {

                audioBG.pitch = Mathf.Lerp(audioBG.pitch, 1f, Time.deltaTime * 5f);
                audioEngines.pitch = Mathf.Lerp(audioEngines.pitch, 1.2f, Time.deltaTime * 5f);
            }

            if (isAccelerating)
            {
                audioEngines.volume = Mathf.Lerp(audioEngines.volume, 1f, Time.deltaTime * 15f);
            }
            else
            {
                audioEngines.volume = Mathf.Lerp(audioEngines.volume, 0, Time.deltaTime * 15f);
            }

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

            if (Input.GetButtonDown(Buttons.Teleport) && energy > 10)
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

            isAccelerating = move.magnitude > 0f;

            if (anmEngineBack.isInitialized)
            {
                if (Input.GetAxis(Buttons.Move_Horizontal) > 0)
                {
                    anmEngineBack.SetBool("BurningBack", true);
                }
                else
                {
                    anmEngineBack.SetBool("BurningBack", false);
                }
            }

            if (anmEngineBottom1.isInitialized && anmEngineBottom2.isInitialized)
            {
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

        }
        else
        {
            if (energy < 10)
            {
                isTeleporting = false;
                cGravity.freezeMovement = false;
                teleportController.Deactivate();
                Time.timeScale = 1f;
            }
            else
            {
                if (Input.GetButtonUp(Buttons.Teleport))
                {
                    if (anmEngineBottom1.isInitialized && anmEngineBottom2.isInitialized && anmEngineBack.isInitialized)
                    {
                        anmEngineBack.SetBool("BurningBack", false);
                        anmEngineBottom1.SetBool("BurningBack", false);
                        anmEngineBottom2.SetBool("BurningBack", false);
                    }
                    anmPlayer.SetTrigger("Teleport");
                    teleportController.Deactivate();
                    Time.timeScale = 1f;

                    audioWarp.PlayOneShot(audioWarp.clip);
                }
            }
        }
    }

    public void EndTeleport()
    {
        isTeleporting = false;
        cGravity.freezeMovement = false;
        transform.position = teleportController.transform.position;
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
            GameObject g = (GameObject)Instantiate(ptclRocks, other.transform.position, ptclRocks.transform.rotation);
            g.SetActive(true);

            audioCrash1.PlayOneShot(audioCrash1.clip);
            audioCrash2.PlayOneShot(audioCrash2.clip);
        }
        else if (other.tag == Tags.EnergyPack)
        {
            energy += energyPackGain;

            energy = Mathf.Min(energy, maxEnergy);

            Destroy(other.gameObject);
        }
        else if (other.tag == Tags.Knowledge)
        {
            GameController.instance.playerKnowledge += knowlegeGain;
            GameController.instance.playerKnowledge = Mathf.Min(GameController.instance.playerKnowledge, GameController.instance.currentLevelKnowledgeNeed);

            Destroy(other.gameObject);
        }
    }
}
