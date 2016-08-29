using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DateAnimController : MonoBehaviour
{
    public GameObject[] objsToActivate;
    public Text txtDate;

    void Start()
    {
        switch (GameController.instance.levelSelected)
        {
            case 1:
                txtDate.text = "C. 2000 AD.";
                break;
            case 2:
                txtDate.text = "C. 1700 AD.";
                break;
            case 3:
                txtDate.text = "C. 400 BC.";
                break;
            case 4:
                txtDate.text = "C. 2500 BC.";
                break;
            case 5:
                txtDate.text = "C. ????";
                break;
            default:
                txtDate.text = "C. ????";
                break;
        }
    }

    public void EndAnimation()
    {
        if (GameController.instance.levelSelected == 1 && GameController.instance.playerKnowledge == 0)
        {
            GetComponent<Animator>().SetTrigger("Tutorial");
        }
        else
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        foreach (GameObject g in objsToActivate)
        {
            g.SetActive(true);
        }

        GameController.instance.gameState = GameState.Playing;

        Destroy(gameObject);
    }
}
