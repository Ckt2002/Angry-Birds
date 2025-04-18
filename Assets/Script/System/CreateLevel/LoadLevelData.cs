using System;
using System.Threading.Tasks;
using UnityEngine;

public class LoadLevelData : MonoBehaviour
{
    public static LoadLevelData Instance;

    [SerializeField] private TextAsset[] levelFiles;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public async Task LoadAsync(int level)
    {
        try
        {
            var textAsset = levelFiles[level - 1];
            Debug.Log(textAsset);
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