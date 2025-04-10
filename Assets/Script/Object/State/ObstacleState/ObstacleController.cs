using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public EObstacleType obstacleType;

    private ObstacleStateMachine stateMachine;

    private void Start()
    {
        stateMachine = GetComponent<ObstacleStateMachine>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.magnitude >= GameStat.Instance.velocityThreshold)
            stateMachine.ChangeState(new ObstacleColliedState(this));
    }
}