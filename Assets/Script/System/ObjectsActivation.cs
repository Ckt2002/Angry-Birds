using UnityEngine;

public class ObjectsActivation : MonoBehaviour
{
    public static ObjectsActivation Instance;

    public int enemiesRemain { get; private set; }
    public int birdsRemain { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void InitializationEnemies(int spawnedNumber) => enemiesRemain = spawnedNumber;
    public void InitializationBirds(int spawnedNumber)
    {
        birdsRemain = spawnedNumber;
    }

    public void EnemiesNumReduce()
    {
        enemiesRemain--;
    }
    public void BirdsNumReduce()
    {
        birdsRemain--;
    }
}
