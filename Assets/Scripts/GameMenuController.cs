using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour
{
    public GameObject pnlPause;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        pnlPause.SetActive(true);
        GameController.SetGameState(GameState.Paused);
    }

    public void Resume()
    {
        pnlPause.SetActive(false);
        GameController.SetGameState(GameState.Playing);
    }

    public void QuitToMenu()
    {
        GameController.SetGameState(GameState.InMenus);
        SaveGame();

        SceneManager.LoadScene(Scenes.LevelSelection);
    }

    public void SaveGame()
    {
        //TO-DO Save Game
    }

    public void Quit()
    {
        SaveGame();

        Application.Quit();
    }
}
