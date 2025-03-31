using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IState currentState;
    private bool hasExecuted;

    public void ChangeState(IState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    private void Update()
    {
        if (currentState == null)
        {
            Debug.Log("Current state is null");
            return;
        }

        if (!hasExecuted)
        {
            currentState.ExecuteOnce();
            hasExecuted = true;
        }

        currentState.ExecuteEveryFrame();
    }
}