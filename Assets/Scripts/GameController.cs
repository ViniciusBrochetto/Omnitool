using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameState gameState;
    public float playerKnowledge;
    public float currentLevelKnowledgeNeed;
    public float pastLevelsNeededKnowledge;
    public int levelSelected = -1;


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

        switch (level)
        {
            case 1:
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

    public static void SetGameState(GameState state)
    {
        instance.gameState = state;
    }
}
