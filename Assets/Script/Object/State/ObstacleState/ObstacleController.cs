using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public EObstacleType obstacleType;

    private ObstacleStateMachine stateMachine;
    private Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        stateMachine = GetComponent<ObstacleStateMachine>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.magnitude >= GameStat.Instance.velocityThreshold)
            stateMachine.ChangeState(new ObstacleColliedState(this));
    }

    public void ObstacleExplosionState(float explosiveDistance, float explosionForce, Vector2 direction)
    {
        if (explosiveDistance <= 0)
        {
            stateMachine?.ChangeState(new ObstacleColliedState(this));
            return;
        }
        else if (explosiveDistance > 0 && explosiveDistance <= 4f)
            stateMachine?.ChangeState(new ObstatcleExplosionState(rb2D, explosionForce, direction));
    }
}