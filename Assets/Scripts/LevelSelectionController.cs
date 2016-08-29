using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionController : MonoBehaviour
{
    public Button btLv1, btLv2, btLv3, btLv4;
    public Animator anmLevelSelector;
    public int currLevelSelected;
    public Image completionFill;

    void Start()
    {
        CheckLevelsUnlocked();
        CalculateCompletion();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            SwitchLevel(true);
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            SwitchLevel(false);
    }

    public void LoadLevel(int level)
    {
        GameController.instance.gameState = GameState.Playing;
        GameController.instance.LoadLevel(level);
    }

    void CheckLevelsUnlocked()
    {
        float k = GameController.instance.playerKnowledge;
        if (k >= (int)LevelKnowledgeToUnlock.level1)
            btLv1.interactable = true;
        if (k >= (int)LevelKnowledgeToUnlock.level2)
            btLv2.interactable = true;
        if (k >= (int)LevelKnowledgeToUnlock.level3)
            btLv3.interactable = true;
        if (k >= (int)LevelKnowledgeToUnlock.level4)
            btLv4.interactable = true;
    }

    void SwitchLevel(bool dirRight)
    {
        anmLevelSelector.SetBool("lv" + currLevelSelected.ToString(), false);

        if (!dirRight && currLevelSelected > 0)
            currLevelSelected--;
        else if (dirRight && currLevelSelected < 3)
            currLevelSelected++;

        anmLevelSelector.SetBool("lv" + currLevelSelected.ToString(), true);
    }

    void CalculateCompletion()
    {
        float completion = 0;
        float k = GameController.instance.playerKnowledge;

        if (k >= (int)LevelKnowledgeToUnlock.level2)
            completion += 0.33f;
        else
        {
            completion += Mathf.Lerp((int)LevelKnowledgeToUnlock.level1, (int)LevelKnowledgeToUnlock.level2, k);
            completionFill.fillAmount = completion;
            return;
        }

        if (k >= (int)LevelKnowledgeToUnlock.level3)
            completion += 0.33f;
        else
        {
            completion += Mathf.Lerp((int)LevelKnowledgeToUnlock.level2, (int)LevelKnowledgeToUnlock.level3, k);
            completionFill.fillAmount = completion;
            return;
        }

        if (k >= (int)LevelKnowledgeToUnlock.level4)
            completion += 0.34f;
        else
        {
            completion += Mathf.Lerp((int)LevelKnowledgeToUnlock.level3, (int)LevelKnowledgeToUnlock.level4, k);
            completionFill.fillAmount = completion;
            return;
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(Scenes.MainMenu);
    }
}

