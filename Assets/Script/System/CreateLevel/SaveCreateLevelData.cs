using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveCreateLevelData : MonoBehaviour
{
    [Min(1)]
    [SerializeField] private int level;
    [SerializeField] private Transform obstacleParent;
    [SerializeField] private Transform enemyParent;

    [ContextMenu("Save or Overwrite Data")]
    public void SaveData()
    {

        if (obstacleParent == null)
        {
            Debug.LogError("Parent obstacle is not assigned!");
            return;
        }

        if (enemyParent == null)
        {
            Debug.LogError("Parent enemy is not assigned!");
            return;
        }

        var obstacles = obstacleParent.GetComponentsInChildren<ObstacleController>();
        var enemies = enemyParent.GetComponentsInChildren<EnemyController>();

        var levelData = new CreateLevelData
        {
            obstacles = new List<ObstacleData>(),
            enemies = new List<EnemyData>()
        };

        foreach (var obstacle in obstacles)
        {
            levelData.obstacles.Add(
                new ObstacleData
                {
                    obstacleType = obstacle.obstacleType,
                    position = obstacle.transform.position,
                    rotation = obstacle.transform.rotation,
                }
            );
        }

        foreach (var enemy in enemies)
        {
            levelData.enemies.Add(
                new EnemyData
                {
                    enemyType = enemy.enemyType,
                    position = enemy.transform.position
                }
            );
        }

        var json = JsonUtility.ToJson(levelData, true);
        var fileName = $"Level {level}.json";
        string directoryPath = Path.Combine(Application.dataPath, "Data", "Levels");
        string fullPath = Path.Combine(directoryPath, fileName);
        SaveToFile(json, fullPath);
    }

    private void SaveToFile(string json, string fullPath)
    {
        try
        {
            File.WriteAllText(fullPath, json);

#if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
#endif

            Debug.Log($"Level data saved successfully to: {fullPath}");
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to save level data: {e.Message}");
        }
    }
}