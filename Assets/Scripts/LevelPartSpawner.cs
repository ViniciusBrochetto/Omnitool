using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelPartSpawner : MonoBehaviour
{
    public static LevelPartSpawner instance;

    public List<LevelPartController> LevelParts;

    private Vector3 spawnPos;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            spawnPos = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0.5f, -Camera.main.transform.position.z));

            SpawnNext();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnNext()
    {
        int r = Random.Range(0, LevelParts.Count);
        GameObject g;

        g = (GameObject)Instantiate(LevelParts[r].gameObject, spawnPos, Quaternion.identity);

        g.SetActive(true);
    }
}
