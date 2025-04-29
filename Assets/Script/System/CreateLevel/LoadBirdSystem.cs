using System;
using System.Collections.Generic;
using Script.System;
using UnityEngine;

public class LoadBirdSystem : MonoBehaviour
{
    public static LoadBirdSystem Instance;

    [SerializeField] private GetBirdForLevelSystem getBirdSystem;

    private Dictionary<byte, byte[]> levelsInfor;
    private byte currentLevel = 1;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public async void Load(int level)
    {
        try
        {
            Debug.Log($"Loading level {level}");
            levelsInfor = new Dictionary<byte, byte[]>();
            await CsvLevelSystem.LoadDataLevelFromCSV(SetLevelDictionary);

            SetCurrentLevel((byte)level);
        }
        catch (Exception e)
        {
            Debug.LogError($"Full Exception Details: {e}");
            if (e.InnerException != null)
            {
                Debug.LogError($"Inner Exception: {e.InnerException.Message}");
                Debug.LogError($"Inner Exception Stack Trace: {e.InnerException.StackTrace}");
            }
        }
    }

    private void SetLevelDictionary(KeyValuePair<byte, byte[]> levelInfor)
    {
        if (!levelsInfor.ContainsKey(levelInfor.Key))
            levelsInfor.Add(levelInfor.Key, levelInfor.Value);
    }

    public void SetCurrentLevel(byte currentLevel)
    {
        this.currentLevel = currentLevel;
        LoadLevel();
    }

    private void LoadLevel()
    {
        getBirdSystem?.LoadBirdsInLevel(levelsInfor[currentLevel]);
    }
}