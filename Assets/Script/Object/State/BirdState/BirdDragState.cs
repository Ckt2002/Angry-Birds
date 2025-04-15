using UnityEngine;

public class BirdDragState : IBirdState
{
    private BirdController bird;

    public BirdDragState(BirdController bird)
    {
        this.bird = bird;
    }

    public void Enter()
    {
        bird.rb2D.bodyType = RigidbodyType2D.Kinematic;
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