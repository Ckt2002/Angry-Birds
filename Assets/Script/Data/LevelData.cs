using System;

[Serializable]
public class LevelData
{
    public int Level = 1;
    public int StarNumber = 0;
    public bool IsLocked = true;
}

[Serializable]
public class LevelManager
{
    public LevelData[] levelDataArr;
}