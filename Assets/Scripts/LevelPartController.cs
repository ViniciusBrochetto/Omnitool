using UnityEngine;

public class LevelPartController : MonoBehaviour
{
    public Transform start, end;
    public int difficulty;

    private bool spawnedNext;

    [SerializeField]
    public Obstacle[] obstacles;

    [SerializeField]
    public Collectible[] collectibles;

    void Start()
    {
        SpawnThings();
    }

    void Update()
    {
        if (Camera.main.WorldToViewportPoint(end.position).x < 0.99f && !spawnedNext)
        {
            LevelPartSpawner.instance.SpawnNext();
            spawnedNext = true;
        }
        if (Camera.main.WorldToViewportPoint(end.position).x < 0f)
            Destroy(gameObject);
    }

    void SpawnThings()
    {
        foreach (Obstacle o in obstacles)
        {
            GameObject g = (GameObject)Instantiate(Resources.Load("ArtContent/Prefabs/ObstA"), o.position.position, Quaternion.identity);
            g.transform.parent = transform;
        }

        foreach (Collectible c in collectibles)
        {
            GameObject g = (GameObject)Instantiate(Resources.Load("ArtContent/Prefabs/EnergyPack"), c.position.position, Quaternion.identity);
            g.transform.parent = transform;
        }
    }
}
