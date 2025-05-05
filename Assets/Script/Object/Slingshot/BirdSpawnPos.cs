using UnityEngine;

public class BirdSpawnPos : MonoBehaviour
{
    public static BirdSpawnPos Instance { get; private set; }

    //TODO: Add code to check which side to spawn
    public static byte birdPosOffset { get; private set; } = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}