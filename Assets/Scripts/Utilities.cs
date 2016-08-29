using UnityEngine;
using System.Collections;

public class Buttons
{
    public static string Boost = "Boost";
    public static string Move_Horizontal = "Horizontal";
    public static string Move_Vertical = "Vertical";
    public static string Pause = "Cancel";
    public static string Teleport = "Teleport";
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

public enum ObstacleType
{
    ObstA,
    ObstB,
    ObstC
}

public enum CollectibleType
{
    EnergyPack,
    b,
    c
}

public enum MovementType
{
    straight,
    sinV,
    sinH,
    orbit
}

public class Tags
{
    public static string EnergyPack = "EnergyPack";
    public static string Obstacle = "Obstacle";
    public static string Knowledge = "Knowledge";
}