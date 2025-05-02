using System;
using System.Threading.Tasks;
using UnityEngine;

public class LoadLevelData : MonoBehaviour
{
    public static LoadLevelData Instance;

    [SerializeField] private TextAsset[] levelFiles;
    [SerializeField] private TextAsset levelManagerFile;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private async void Start()
    {
        await LoadLevelManagerAsync();
    }

    private async Task LoadLevelManagerAsync()
    {
        try
        {
            var levelManagerJson = levelManagerFile?.text;
            var data = await Task.Run(() => JsonUtility.FromJson<LevelManager>(levelManagerJson));
            LoadLevelManager.Instance.Load(data);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    public async Task LoadLevelDataAsync(int level)
    {
        try
        {
            var textAsset = levelFiles[level - 1];
            string levelJson = textAsset.text;
            var data = await Task.Run(() => JsonUtility.FromJson<CreateLevelData>(levelJson));
            LoadMapSystem.Instance.Load(data);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }
}