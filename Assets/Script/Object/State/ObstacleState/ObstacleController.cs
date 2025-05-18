using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public EObstacleType obstacleType;

    private ObstacleStateMachine stateMachine;
    private Rigidbody2D rb2D;
    private SoundManager soundManager;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        stateMachine = GetComponent<ObstacleStateMachine>();
    }

    private void Start()
    {
        soundManager = SoundManager.Instance;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.magnitude >= GameStat.Instance.velocityThreshold)
            stateMachine.ChangeState(new ObstacleColliedState(this, soundManager));
    }

    public void ObstacleExplosionState(float explosiveDistance, float explosionForce, Vector2 direction)
    {
        if (explosiveDistance <= 0)
        {
            stateMachine?.ChangeState(new ObstacleColliedState(this, soundManager));
            return;
        }
        else if (explosiveDistance > 0 && explosiveDistance <= 4f)
            stateMachine?.ChangeState(new ObstatcleExplosionState(rb2D, explosionForce, direction));
    }
}