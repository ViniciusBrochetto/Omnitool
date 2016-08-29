using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameState gameState;
    public float playerKnowledge = 0;
    public float currentLevelKnowledgeNeed = 0;
    public int levelSelected = -1;


    void Awake()
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

        switch (level)
        {
            case 1:
                currentLevelKnowledgeNeed = (float)LevelKnowledgeToUnlock.level1;
                break;
            case 2:
                currentLevelKnowledgeNeed = (float)LevelKnowledgeToUnlock.level2;
                break;
            case 3:
                currentLevelKnowledgeNeed = (float)LevelKnowledgeToUnlock.level3;
                break;
            case 4:
                currentLevelKnowledgeNeed = (float)LevelKnowledgeToUnlock.level4;
                break;
            default:
                currentLevelKnowledgeNeed = 0f;
                break;
        }


        SceneManager.LoadScene(Scenes.MainGame);
    }

    public static void SetGameState(GameState state)
    {
        instance.gameState = state;
    }
}
