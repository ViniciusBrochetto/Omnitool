using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Animator anmMenus;

    void Update()
    {
        if (Input.anyKey)
        {
            anmMenus.SetTrigger("End");
        }
    }

    public void StartGame()
    {
        GameController.instance.gameState = GameState.InMenus;
        SceneManager.LoadScene(Scenes.LevelSelection);
    }
}
