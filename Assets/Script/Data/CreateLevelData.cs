using System;
using System.Collections.Generic;

[Serializable]
public class CreateLevelData
{
    public List<EnemyData> enemies;
    public List<ObstacleData> obstacles;
}