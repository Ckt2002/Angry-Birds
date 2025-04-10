using UnityEngine;

public class ObstacleStateMachine : MonoBehaviour
{
    private IObstacleState currentState;

    public void ChangeState(IObstacleState obstacleState)
    {
        currentState?.Exit();
        currentState = obstacleState;
        currentState?.Enter();
    }
}