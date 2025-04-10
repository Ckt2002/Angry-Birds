using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EEnemyType enemyType;

    private EnemyStateMachine stateMachine;

    private void Start()
    {
        stateMachine = GetComponent<EnemyStateMachine>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.magnitude >= GameStat.Instance.velocityThreshold)
            stateMachine?.ChangeState(new EnemyColliedState(this));
    }
}