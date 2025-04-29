using UnityEngine;

public class BirdStateMachine : MonoBehaviour
{
    private IBirdState currentState;
    private bool hasExecuted;

    public void ChangeState(IBirdState newState)
    {
        currentState?.Exit();
        currentState = newState;
        if (currentState == null)
            return;

        currentState.Enter();
    }

    private void Update()
    {
        if (currentState == null)
            return;

        if (!hasExecuted)
        {
            currentState.ExecuteOnce();
            hasExecuted = true;
        }

        currentState.ExecuteEveryFrame();
    }
}