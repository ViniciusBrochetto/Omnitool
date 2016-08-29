using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelSelectionController : MonoBehaviour
{
    public Button btLv1, btLv2, btLv3, btLv4, btLv5;
    public Animator anmLevelSelector;
    public int currLevelSelected;
    public Image completionFill;

    public List<GameObject> objectsToAnimate;

    void Start()
    {
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

    //IEnumerator CheckLevelsUnlocked()
    //{
    //    float k = GameController.instance.playerKnowledge;
    //    if (k >= (int)LevelKnowledgeToUnlock.level1)
    //        btLv1.interactable = true;
    //    if (k >= (int)LevelKnowledgeToUnlock.level2)
    //        btLv2.interactable = true;
    //    if (k >= (int)LevelKnowledgeToUnlock.level3)
    //        btLv3.interactable = true;
    //    if (k >= (int)LevelKnowledgeToUnlock.level4)
    //        btLv4.interactable = true;
    //}

    void SwitchLevel(bool dirRight)
    {
        anmLevelSelector.SetBool("lv" + currLevelSelected.ToString(), false);

        if (!dirRight && currLevelSelected > 0)
            currLevelSelected--;
        else if (dirRight && currLevelSelected < 3)
            currLevelSelected++;

        anmLevelSelector.SetBool("lv" + currLevelSelected.ToString(), true);
    }

    IEnumerator CalculateCompletion()
    {
        float completion = 0;
        float k = GameController.instance.playerKnowledge;
        float aux;
        float aux2;
        bool calculated = false;

        #region Calculate

        if (k >= (int)LevelKnowledgeToUnlock.level2)
            completion += 0.25f;
        else
        {
            aux = (float)LevelKnowledgeToUnlock.level1;
            aux2 = (int)LevelKnowledgeToUnlock.level2;
            completion += ((k - aux) / (aux2 - aux)) / 4f;
            calculated = true;
        }
        if (!calculated)
        {
            if (k >= (int)LevelKnowledgeToUnlock.level3)
                completion += 0.25f;
            else
            {
                aux = (float)LevelKnowledgeToUnlock.level2;
                aux2 = (int)LevelKnowledgeToUnlock.level3;
                completion += ((k - aux) / (aux2 - aux)) / 4f;
                calculated = true;
            }

        }

        if (!calculated)
        {
            if (k >= (int)LevelKnowledgeToUnlock.level4)
                completion += 0.25f;
            else
            {
                aux = (float)LevelKnowledgeToUnlock.level3;
                aux2 = (int)LevelKnowledgeToUnlock.level4;
                completion += ((k - aux) / (aux2 - aux)) / 4f;
                calculated = true;
            }
        }

        if (!calculated)
        {
            if (k >= (int)LevelKnowledgeToUnlock.level5)
                completion += 0.25f;
            else
            {
                aux = (float)LevelKnowledgeToUnlock.level4;
                aux2 = (int)LevelKnowledgeToUnlock.level5;
                completion += ((k - aux) / (aux2 - aux)) / 4f;
                calculated = true;
            }
        }

        #endregion

        #region Animate

        float count = 0f;
        int lastIndex = -1;

        while (count <= 1f)
        {
            int indexCounted = (int)((float)count / 0.0625f);

            if (indexCounted > lastIndex)
            {
                foreach (GameObject g in objectsToAnimate)
                {
                    int indexInList = objectsToAnimate.IndexOf(g);

                    if (indexInList > lastIndex)
                    {
                        if (g.GetComponent<Button>())
                        {
                            g.GetComponent<Button>().enabled = true;
                        }
                        else
                        {
                            g.SetActive(true);
                        }
                    }
                }

                lastIndex = indexCounted;
            }


            count += Time.deltaTime / 4f;
            yield return new WaitForEndOfFrame();
        }


        #endregion

    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(Scenes.MainMenu);
    }
}

