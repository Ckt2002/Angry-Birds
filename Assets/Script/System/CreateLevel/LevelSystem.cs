using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem Instance;

    [Min(1), SerializeField] private int level = 1;
    public int GetLevel => level;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        //LoadLevel();
    }

    public void LoadLevel()
    {
        LoadBirdSystem.Instance.Load(level);
        _ = LoadLevelData.Instance.LoadLevelDataAsync(level);
    }

    public void NextLevel()
    {
        level++;
        LoadLevel();
    }

    public void SetLevel(int level)
    {
        this.level = level;
        LoadLevel();
    }

    [ContextMenu("Load map")]
    public void LoadLevelForEditor()
    {
        _ = LoadLevelData.Instance.LoadLevelDataAsync(level);
    }
}