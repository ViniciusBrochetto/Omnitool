using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelPartSpawner : MonoBehaviour
{
    public static LevelPartSpawner instance;

    public int startWithID = -1;
    public LevelPartController monolith;
    public bool spawnMonolith = false;

    public List<LevelPartController> LevelParts1;
    public List<LevelPartController> LevelParts2;
    public List<LevelPartController> LevelParts3;
    public List<LevelPartController> LevelParts4;

    public List<LevelPartController> currLevelParts;

    private Vector3 spawnPos;

    void Start()
    {
        currLevelParts = new List<LevelPartController>();

        switch (GameController.instance.levelSelected)
        {
            case 1:
                currLevelParts = new List<LevelPartController>(LevelParts1);
                break;
            case 2:
                currLevelParts = new List<LevelPartController>(LevelParts2);
                break;
            case 3:
                currLevelParts = new List<LevelPartController>(LevelParts3);
                break;
            case 4:
                currLevelParts = new List<LevelPartController>(LevelParts4);
                break;
            case 5:
                currLevelParts.AddRange(LevelParts1);
                currLevelParts.AddRange(LevelParts2);
                currLevelParts.AddRange(LevelParts3);
                currLevelParts.AddRange(LevelParts4);
                break;
            default:
                currLevelParts = LevelParts1;
                break;
        }

        if (instance == null)
        {
            instance = this;
            spawnPos = Camera.main.ViewportToWorldPoint(new Vector3(1.3f, 0.5f, -Camera.main.transform.position.z));

            SpawnNext();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnNext()
    {
        GameObject g;
        if (!spawnMonolith)
        {
            int r;
            if (startWithID == -1)
                r = Random.Range(0, currLevelParts.Count);
            else
            {
                r = startWithID - 1;
                startWithID = -1;
            }


            g = (GameObject)Instantiate(currLevelParts[r].gameObject, spawnPos, Quaternion.identity);
        }
        else
        {
            g = (GameObject)Instantiate(monolith.gameObject, spawnPos, Quaternion.identity);
        }


        g.transform.parent = this.transform;
        g.SetActive(true);
    }
}
