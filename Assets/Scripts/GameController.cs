using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameState gameState;
    public float playerKnowledge;
    public float playerScore;
    public float playerTopScore;
    public float currentLevelKnowledgeNeed;
    public float pastLevelsNeededKnowledge;
    public int levelSelected = -1;
    public bool firstTimeLevel5 = true;
    public int scoreTable;


    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;

            //Initialization
            gameState = GameState.InMenus;

#if UNITY_STANDALONE
            playerKnowledge = 0;
            currentLevelKnowledgeNeed = 100f;
#endif

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadLevel(int level)
    {
        levelSelected = level;
        pastLevelsNeededKnowledge = 0f;

        switch (level)
        {
            case 1:
                pastLevelsNeededKnowledge = 0f;

                currentLevelKnowledgeNeed = (float)LevelKnowledgeToUnlock.level2;
                break;
            case 2:
                pastLevelsNeededKnowledge += (float)LevelKnowledgeToUnlock.level2;

                currentLevelKnowledgeNeed = (float)LevelKnowledgeToUnlock.level3;
                break;
            case 3:
                pastLevelsNeededKnowledge += (float)LevelKnowledgeToUnlock.level3;

                currentLevelKnowledgeNeed = (float)LevelKnowledgeToUnlock.level4;
                break;
            case 4:
                pastLevelsNeededKnowledge += (float)LevelKnowledgeToUnlock.level4;

                currentLevelKnowledgeNeed = (float)LevelKnowledgeToUnlock.level5;
                break;
            default:
                currentLevelKnowledgeNeed = 0f;
                break;
        }


        SceneManager.LoadScene(Scenes.MainGame);
    }

    public void SetLevel(int l)
    {
        levelSelected = l;
    }

    public void UploadTopScore()
    {
        if (playerScore > playerTopScore)
        {
            if (GameJolt.API.Manager.Instance.CurrentUser != null)
            {
                GameJolt.API.Scores.Add((int)playerScore, playerScore + " Knowledge", scoreTable, null, (bool success) =>
                {
                    Debug.Log(string.Format("Score Add {0}.", success ? "Successful" : "Failed"));
                });
            }
            else
            {
                GameJolt.API.Scores.Add((int)playerScore, playerScore + " Knowledge", "Guest", scoreTable, null, (bool success) =>
                {
                    Debug.Log(string.Format("Score Add {0}.", success ? "Successful" : "Failed"));
                });
            }
        }

        playerTopScore = playerScore;
        playerScore = 0f;
    }

    public static void SetGameState(GameState state)
    {
        instance.gameState = state;
    }
}
