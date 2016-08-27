using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(Scenes.LevelSelection);
    }

    public void ContinueGame()
    {
        GameController.SetGameState(GameState.Playing);
        SceneManager.LoadScene(Scenes.MainGame);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
