using UnityEngine;
using System.Collections;

public class Buttons
{
    public static string Boost = "Boost";
    public static string Move_Horizontal = "Horizontal";
    public static string Move_Vertical = "Vertical";
    public static string Pause = "Cancel";
}

public enum GameState
{
    Playing,
    Paused,
    InMenus,
    GameOver
}

public class Scenes
{
    public static string MainMenu = "MainMenu";
    public static string MainGame = "MainGame";
    public static string LevelSelection = "LevelSelection";
}

public enum LevelKnowledgeToUnlock
{
    level1 = 0,
    level2 = 100,
    level3 = 200,
    level4 = 400
}
