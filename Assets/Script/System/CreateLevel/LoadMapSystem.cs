using UnityEngine;

public class LoadMapSystem : MonoBehaviour
{
    public static LoadMapSystem Instance;

    [SerializeField] private SOObstacles obstaclesObj;
    [SerializeField] private SOEnemy enemiesObj;
    [SerializeField] private Transform obstacleParent;
    [SerializeField] private Transform enemyParent;

    private ObjectsActivation objectsInLevel;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        objectsInLevel = ObjectsActivation.Instance;
    }

    public void Load(CreateLevelData levelData)
    {
        foreach (var obstacleData in levelData.obstacles)
        {
            var index = obstacleData.obstacleType;
            var obstacle = Instantiate(obstaclesObj.obstaclePrefabs[(int)index], obstacleParent);
            obstacle.transform.position = obstacleData.position;
            obstacle.transform.rotation = obstacleData.rotation;
        }

        objectsInLevel?.InitializationEnemies(levelData.enemies.Count);
        foreach (var enemyData in levelData.enemies)
        {
            var index = enemyData.enemyType;
            var enemy = Instantiate(enemiesObj.enemyPrefabs[(int)index], enemyParent);
            enemy.transform.position = enemyData.position;
        }
    }
}