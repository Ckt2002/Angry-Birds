using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem Instance;

    [Min(1), SerializeField] private int level = 1;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        LoadLevel();
    }

    [ContextMenu("LoadLevel")]
    public void Load()
    {
        LoadLevel();
    }

    public void LoadLevel()
    {
        LoadBirdSystem.Instance.Load(level);
        _ = LoadLevelData.Instance.LoadAsync(level);
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
}