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
    level3 = 300,
    level4 = 600,
    level5 = 1000
}

public enum CollectibleType
{
    EnergyPack,
    Knowledge,
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


[System.Serializable]
public class Obstacle
{
    public float size = 0.5f;
    public Transform position;
    public ObjMoverParams objMoverParams;
}


[System.Serializable]
public class Collectible
{
    public float size = 1.5f;
    public Transform position;
    public CollectibleType type;

    public ObjMoverParams objMoverParams;
}

[System.Serializable]
public class ObjMoverParams
{
    public MovementType movementType;
    public float STR_speed;
    public float SIN_frequency;
    public float SIN_amplitude;
    public float ORB_radius;
    public float ORB_speed;
}