using UnityEngine;

public class GameStat : MonoBehaviour
{
    public static GameStat Instance;

    public float velocityThreshold = 1.9f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}