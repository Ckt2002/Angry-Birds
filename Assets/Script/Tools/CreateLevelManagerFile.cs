#if UNITY_EDITOR
using System;
using System.IO;
using UnityEngine;

public class CreateLevelManagerFile : MonoBehaviour
{
    [SerializeField] private int maxLevel = 10;
    [SerializeField] bool lockAllLevel = true;

    [ContextMenu("Create level manager file")]
    public void CreateFile()
    {
        var level = new LevelManager();
        level.levelDataArr = new LevelData[maxLevel];

        level.levelDataArr[0] = CreateLevelData(1, false);

        for (int i = 1; i < maxLevel; i++)
        {
            level.levelDataArr[i] = CreateLevelData(i + 1, lockAllLevel);
        }

        var json = JsonUtility.ToJson(level, true);
        var fileName = $"Level manager.json";
        string directoryPath = Path.Combine(Application.dataPath, "Data", "Level Manager");
        string fullPath = Path.Combine(directoryPath, fileName);
        SaveToFile(json, fullPath);
    }

    private LevelData CreateLevelData(int level, bool isLocked)
    {
        return new LevelData
        {
            Level = level,
            StarNumber = 0,
            IsLocked = isLocked,
        };
    }

    private void SaveToFile(string json, string fullPath)
    {
        try
        {
            File.WriteAllText(fullPath, json);
            UnityEditor.AssetDatabase.Refresh();

            Debug.Log($"Level manager saved successfully to: {fullPath}");
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to save level manager: {e}");
        }
    }
}
#endif