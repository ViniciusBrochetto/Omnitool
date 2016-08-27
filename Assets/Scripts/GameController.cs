using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameState gameState;
    public int playerKnowledge = 0;
    public int levelSelected = -1;


    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;

            //Initialization
            gameState = GameState.Playing;
            playerKnowledge = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadLevel(int level)
    {
        levelSelected = level;
        SceneManager.LoadScene(Scenes.MainGame);
    }

    public static void SetGameState(GameState state)
    {
        instance.gameState = state;
    }
}
