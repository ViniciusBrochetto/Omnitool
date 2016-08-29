using UnityEngine;
using System.Collections;

public class SpriteRandomizer : MonoBehaviour
{
    SpriteRenderer spRenderer;
    public bool obstacle;

    void Start()
    {
        spRenderer = GetComponent<SpriteRenderer>();

        if (!obstacle)
        {
            switch (GameController.instance.levelSelected)
            {
                case 1:
                    spRenderer.sprite = Resources.Load<Sprite>(SpritePaths.getRandomLV1());
                    break;
                case 2:
                    spRenderer.sprite = Resources.Load<Sprite>(SpritePaths.getRandomLV2());
                    break;
                case 3:
                    spRenderer.sprite = Resources.Load<Sprite>(SpritePaths.getRandomLV3());
                    break;
                case 4:
                    spRenderer.sprite = Resources.Load<Sprite>(SpritePaths.getRandomLV4());
                    break;
                case 5:
                    spRenderer.sprite = Resources.Load<Sprite>(SpritePaths.getRandomLV5());
                    break;
                default:
                    spRenderer.sprite = Resources.Load<Sprite>(SpritePaths.getRandomLV1());
                    break;
            }
        }
        else
        {
            spRenderer.sprite = Resources.Load<Sprite>(SpritePaths.getRandomRock());
        }

        PolygonCollider2D c = gameObject.AddComponent<PolygonCollider2D>();
        c.isTrigger = true;
    }
}

public static class SpritePaths
{
    public static string[] LV1_Sprites = {  "ArtContent/Levels/Lv1/001",
                                            "ArtContent/Levels/Lv1/002",
                                            "ArtContent/Levels/Lv1/003",
                                            "ArtContent/Levels/Lv1/004",
                                            "ArtContent/Levels/Lv1/005",
                                            "ArtContent/Levels/Lv1/006",
                                            "ArtContent/Levels/Lv1/007",
                                            "ArtContent/Levels/Lv1/008",
                                            "ArtContent/Levels/Lv1/009",
                                            "ArtContent/Levels/Lv1/010",
                                            "ArtContent/Levels/Lv1/011",
                                            "ArtContent/Levels/Lv1/012"};

    public static string[] LV2_Sprites = {  "ArtContent/Levels/Lv2/001",
                                            "ArtContent/Levels/Lv2/002",
                                            "ArtContent/Levels/Lv2/003",
                                            "ArtContent/Levels/Lv2/004",
                                            "ArtContent/Levels/Lv2/005",
                                            "ArtContent/Levels/Lv2/006",
                                            "ArtContent/Levels/Lv2/007",
                                            "ArtContent/Levels/Lv2/008",
                                            "ArtContent/Levels/Lv2/009",
                                            "ArtContent/Levels/Lv2/010",
                                            "ArtContent/Levels/Lv2/011",
                                            "ArtContent/Levels/Lv2/012"};

    public static string[] LV3_Sprites = {  "ArtContent/Levels/Lv3/001",
                                            "ArtContent/Levels/Lv3/002",
                                            "ArtContent/Levels/Lv3/003",
                                            "ArtContent/Levels/Lv3/004",
                                            "ArtContent/Levels/Lv3/005",
                                            "ArtContent/Levels/Lv3/006"};

    public static string[] LV4_Sprites = {  "ArtContent/Levels/Lv4/001",
                                            "ArtContent/Levels/Lv4/002",
                                            "ArtContent/Levels/Lv4/004",
                                            "ArtContent/Levels/Lv4/005",
                                            "ArtContent/Levels/Lv4/006",
                                            "ArtContent/Levels/Lv4/007"};


    public static string[] Rock_Sprites = {  "ArtContent/Rocks/001",
                                             "ArtContent/Rocks/002",
                                             "ArtContent/Rocks/003",
                                             "ArtContent/Rocks/004",
                                             "ArtContent/Rocks/005",
                                             "ArtContent/Rocks/006",
                                             "ArtContent/Rocks/007"};


    public static string getRandomLV1()
    {
        return LV1_Sprites[Random.Range(0, LV1_Sprites.Length)];
    }

    public static string getRandomLV2()
    {
        return LV2_Sprites[Random.Range(0, LV2_Sprites.Length)];
    }

    public static string getRandomLV3()
    {
        return LV3_Sprites[Random.Range(0, LV3_Sprites.Length)];
    }

    public static string getRandomLV4()
    {
        return LV4_Sprites[Random.Range(0, LV4_Sprites.Length)];
    }

    public static string getRandomLV5()
    {
        switch (Random.Range(1, 5))
        {
            case 1:
                getRandomLV1();
                break;
            case 2:
                getRandomLV2();
                break;
            case 3:
                getRandomLV3();
                break;
            case 4:
                getRandomLV4();
                break;
            default:
                getRandomLV1();
                break;
        }
        return LV4_Sprites[Random.Range(0, LV4_Sprites.Length)];
    }

    public static string getRandomRock()
    {
        return Rock_Sprites[Random.Range(0, Rock_Sprites.Length)];
    }
}
