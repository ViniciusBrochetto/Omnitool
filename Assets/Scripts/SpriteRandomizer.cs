using UnityEngine;
using System.Collections;

public class SpriteRandomizer : MonoBehaviour
{
    SpriteRenderer spRenderer;
    public bool obstacle;

    void Awake()
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
    public static string[] LV1_Sprites = {  "ArtContent/Cenarios/Lv1/001",
                                            "ArtContent/Cenarios/Lv1/002",
                                            "ArtContent/Cenarios/Lv1/003",
                                            "ArtContent/Cenarios/Lv1/004",
                                            "ArtContent/Cenarios/Lv1/005",
                                            "ArtContent/Cenarios/Lv1/006",
                                            "ArtContent/Cenarios/Lv1/007",
                                            "ArtContent/Cenarios/Lv1/008",
                                            "ArtContent/Cenarios/Lv1/009",
                                            "ArtContent/Cenarios/Lv1/010",
                                            "ArtContent/Cenarios/Lv1/011",
                                            "ArtContent/Cenarios/Lv1/012"};

    public static string[] LV2_Sprites = {  "ArtContent/Cenarios/Lv2/001",
                                            "ArtContent/Cenarios/Lv2/002",
                                            "ArtContent/Cenarios/Lv2/003",
                                            "ArtContent/Cenarios/Lv2/004",
                                            "ArtContent/Cenarios/Lv2/005",
                                            "ArtContent/Cenarios/Lv2/006",
                                            "ArtContent/Cenarios/Lv2/007",
                                            "ArtContent/Cenarios/Lv2/008",
                                            "ArtContent/Cenarios/Lv2/009",
                                            "ArtContent/Cenarios/Lv2/010",
                                            "ArtContent/Cenarios/Lv2/011",
                                            "ArtContent/Cenarios/Lv2/012"};

    public static string[] LV3_Sprites = {  "ArtContent/Cenarios/Lv3/001",
                                            "ArtContent/Cenarios/Lv3/002",
                                            "ArtContent/Cenarios/Lv3/003",
                                            "ArtContent/Cenarios/Lv3/004",
                                            "ArtContent/Cenarios/Lv3/005",
                                            "ArtContent/Cenarios/Lv3/006"};

    public static string[] LV4_Sprites = {  "ArtContent/Cenarios/Lv4/001",
                                            "ArtContent/Cenarios/Lv4/002",
                                            "ArtContent/Cenarios/Lv4/003",
                                            "ArtContent/Cenarios/Lv4/004",
                                            "ArtContent/Cenarios/Lv4/005",
                                            "ArtContent/Cenarios/Lv4/006",
                                            "ArtContent/Cenarios/Lv4/007"};


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

    public static string getRandomRock()
    {
        return Rock_Sprites[Random.Range(0, Rock_Sprites.Length)];
    }
}
