using UnityEngine;

public class GameStat : MonoBehaviour
{
    public static GameStat Instance;
    public float velocityThreshold = 1.9f;
    public byte maxLevel = 10;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }
}