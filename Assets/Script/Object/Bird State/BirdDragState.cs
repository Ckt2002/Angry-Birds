using UnityEngine;

public class BirdDragState : IState
{
    private BirdController bird;

    public BirdDragState(BirdController bird)
    {
        this.bird = bird;
    }

    public void Enter()
    {
        bird.GetRb2D().bodyType = RigidbodyType2D.Dynamic;
    }

    public void ExecuteOnce()
    {
        // Nothing to do
    }

    public void ExecuteEveryFrame()
    {
        // Nothing to do
    }

    public void Exit()
    {
        bird = null;
    }
}