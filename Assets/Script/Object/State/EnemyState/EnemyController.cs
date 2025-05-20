using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EEnemyType enemyType;

    [SerializeField] private float velocityThreshold = 5f;

    private EnemyStateMachine stateMachine;
    private Rigidbody2D rb2D;
    private SoundManager soundManager;
    private ObjectsActivation objectsActivation;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        stateMachine = GetComponent<EnemyStateMachine>();
    }

    private void Start()
    {
        soundManager = SoundManager.Instance;
        objectsActivation = ObjectsActivation.Instance;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.magnitude >= velocityThreshold)
            stateMachine?.ChangeState(new EnemyColliedState(this, soundManager, objectsActivation));
    }

    public void EnemyExplosionState(float explosiveDistance, float explosionForce, Vector2 direction)
    {
        if (explosiveDistance <= 0)
        {
            stateMachine?.ChangeState(new EnemyColliedState(this, soundManager, objectsActivation));
            return;
        }
        else if (explosiveDistance > 0 && explosiveDistance <= 4f)
            stateMachine?.ChangeState(new EnemyExplosionState(rb2D, explosionForce, direction));
    }
}