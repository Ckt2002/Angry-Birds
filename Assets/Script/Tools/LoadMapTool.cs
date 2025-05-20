
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class LoadMapTool : MonoBehaviour
{
    [SerializeField] private TextAsset[] levelFiles;
    [SerializeField, Range(1, 100)]
    private int level;
    [SerializeField] private SOObstacles obstaclesObj;
    [SerializeField] private SOEnemy enemiesObj;
    [SerializeField] private Transform obstacleParent;
    [SerializeField] private Transform enemyParent;

    [ContextMenu("Load map")]
    public void LoadMapInEditor()
    {
        Delete();
        _ = LoadLevelDataAsync(level);
    }

    [ContextMenu("Delete map")]
    public void DeleteMapInEditor()
    {
        Delete();
    }

    private async Task LoadLevelDataAsync(int level)
    {
        try
        {
            var textAsset = levelFiles[level - 1];
            string levelJson = textAsset.text;
            var data = await Task.Run(() => JsonUtility.FromJson<CreateLevelData>(levelJson));
            Load(data);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    private void Load(CreateLevelData levelData)
    {
        if (obstacleParent == null)
        {
            GameObject parentObj = GameObject.Find("Obstacles");
            obstacleParent = parentObj.transform;
        }

        if (enemyParent == null)
        {
            GameObject parentObj = GameObject.Find("Enemies");
            enemyParent = parentObj.transform;
        }

        foreach (var obstacleData in levelData.Obstacles)
        {
            var index = obstacleData.obstacleType;
            var obstacle = Instantiate(obstaclesObj.obstaclePrefabs[(int)index], obstacleParent);
            obstacle.transform.position = obstacleData.position;
            obstacle.transform.rotation = obstacleData.rotation;
        }

        foreach (var enemyData in levelData.Enemies)
        {
            var index = enemyData.enemyType;
            var enemy = Instantiate(enemiesObj.enemyPrefabs[(int)index], enemyParent);
            enemy.transform.position = enemyData.position;
        }
    }

    private void Delete()
    {
        var obstacleChildren = new List<Transform>();
        foreach (Transform child in obstacleParent)
        {
            obstacleChildren.Add(child);
        }

        var enemyChildren = new List<Transform>();
        foreach (Transform child in enemyParent)
        {
            enemyChildren.Add(child);
        }

        foreach (Transform child in obstacleChildren)
        {
#if UNITY_EDITOR
            Undo.DestroyObjectImmediate(child.gameObject);
#endif
        }

        foreach (Transform child in enemyChildren)
        {
#if UNITY_EDITOR
            Undo.DestroyObjectImmediate(child.gameObject);
#endif
        }
    }
}