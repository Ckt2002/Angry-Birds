using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    public static EnemySystem Instance { get; private set; }

    private GameObject[] enemies;
    public int enemyRemain { get; private set; }


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag(nameof(Tags.Enemy));
        enemyRemain = enemies.Length;
    }

    public void EnemyReduce()
    {
        enemyRemain--;
    }
}