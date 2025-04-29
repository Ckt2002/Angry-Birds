using System;
using System.Collections.Generic;

[Serializable]
public class CreateLevelData
{
    public int Level = 1;
    public int StarNumber = 0;
    public bool IsLocked = true;
    public List<EnemyData> Enemies;
    public List<ObstacleData> Obstacles;
}