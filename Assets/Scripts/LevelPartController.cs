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
            if (o != null)
            {
                GameObject g = (GameObject)Instantiate(Resources.Load("Prefabs/Obstacle"), o.position.position, o.position.rotation);
                g.transform.localScale = Vector3.one * o.size;
                g.transform.parent = transform;
                g.GetComponent<ObjectMover>().objMoverParams = o.objMoverParams;
            }
        }

        foreach (Collectible c in collectibles)
        {
            if (c != null)
            {
                GameObject g = (GameObject)Instantiate(Resources.Load("Prefabs/" + c.type.ToString()), c.position.position, c.position.rotation);
                g.transform.localScale = Vector3.one * c.size;
                g.transform.parent = transform;
                g.GetComponent<ObjectMover>().objMoverParams = c.objMoverParams;
            }
        }
    }
}
