using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public EObstacleType obstacleType;
    [SerializeField] float velocityThreshold;

    private ObstacleStateMachine stateMachine;
    private Rigidbody2D rb2D;
    private SoundManager soundManager;
    private string particleName = ObstacleNames.Wood;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        stateMachine = GetComponent<ObstacleStateMachine>();

        if (name.Contains(ObstacleNames.Glass))
            particleName = ObstacleNames.Glass;
        else if (name.Contains(ObstacleNames.Stone))
            particleName = ObstacleNames.Stone;
    }

    private void Start()
    {
        soundManager = SoundManager.Instance;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.magnitude >= velocityThreshold)
            stateMachine.ChangeState(new ObstacleColliedState(this, soundManager, particleName));
    }

    public void ObstacleExplosionState(float explosiveDistance, float explosionForce, Vector2 direction)
    {
        if (explosiveDistance <= 0)
        {
            stateMachine?.ChangeState(new ObstacleColliedState(this, soundManager, particleName));
            return;
        }
        else if (explosiveDistance > 0 && explosiveDistance <= 4f)
            stateMachine?.ChangeState(new ObstatcleExplosionState(rb2D, explosionForce, direction));
    }
}