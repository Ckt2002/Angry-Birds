using UnityEngine;

public class LoadLevelManager : MonoBehaviour
{
    public static LoadLevelManager Instance;
    public LevelManager levelManagerData { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void Load(LevelManager data)
    {
        levelManagerData = data;
    }
}
