using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EEnemyType enemyType;

    private EnemyStateMachine stateMachine;
    private Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        stateMachine = GetComponent<EnemyStateMachine>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.magnitude >= GameStat.Instance.velocityThreshold)
            stateMachine?.ChangeState(new EnemyColliedState(this));
    }

    public void EnemyExplosionState(float explosiveDistance, float explosionForce, Vector2 direction)
    {
        if (explosiveDistance <= 0)
        {
            stateMachine?.ChangeState(new EnemyColliedState(this));
            return;
        }
        else if (explosiveDistance > 0 && explosiveDistance <= 4f)
            stateMachine?.ChangeState(new EnemyExplosionState(rb2D, explosionForce, direction));
    }
}