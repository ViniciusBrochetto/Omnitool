using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelPartSpawner : MonoBehaviour
{
    public int startWithID = -1;

    public static LevelPartSpawner instance;

    public List<LevelPartController> LevelParts;

    private Vector3 spawnPos;

    void Start()
    {
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
        int r;
        if (startWithID == -1)
            r = Random.Range(0, LevelParts.Count);
        else
        {
            r = startWithID - 1;
            startWithID = -1;
        }

        GameObject g;

        g = (GameObject)Instantiate(LevelParts[r].gameObject, spawnPos, Quaternion.identity);

        g.transform.parent = this.transform;
        g.SetActive(true);
    }
}
