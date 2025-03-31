using System;
using System.Collections.Generic;
using Script.System;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem Instance;

    private Dictionary<byte, byte[]> levelsInfor;
    private byte currentLevel = 1;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private async void Start()
    {
        try
        {
            levelsInfor = new Dictionary<byte, byte[]>();
            await CsvLevelSystem.LoadDataLevelFromCSV("Level", SetLevelDictionary);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    private void SetLevelDictionary(KeyValuePair<byte, byte[]> levelInfor)
    {
        if (!levelsInfor.ContainsKey(levelInfor.Key))
        {
            levelsInfor.Add(levelInfor.Key, levelInfor.Value);
            Debug.Log(levelsInfor.Count);
        }
    }

    private void LoadLevel()
    {
        // BirdSystem.LoadBirdsInLevel(levelsInfor[currentLevel]);
    }

    public void SetCurrentLevel(byte currentLevel)
    {
        this.currentLevel = currentLevel;
    }
}