using UnityEngine;

public class LoadMapSystem : MonoBehaviour
{
    public static LoadMapSystem Instance;

    [SerializeField] private SOObstacles obstaclesObj;
    [SerializeField] private SOEnemy enemiesObj;
    [SerializeField] private Transform obstacleParent;
    [SerializeField] private Transform enemyParent;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void Load(CreateLevelData levelData)
    {
        foreach (var obstacle in levelData.obstacles)
        {
            var index = obstacle.obstacleType;
            var obj = Instantiate(obstaclesObj.obstaclePrefabs[(int)index], obstacleParent);
            obj.transform.position = obstacle.position;
            //obj.transform.rotation = obstacle.rotation;
        }

        foreach (var enemy in levelData.enemies)
        {
            var index = enemy.enemyType;
            var obj = Instantiate(enemiesObj.enemyPrefabs[(int)index], enemyParent);
            obj.transform.position = enemy.position;
        }
    }
}