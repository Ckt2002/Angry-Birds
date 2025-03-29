using System;

public class BirdLaunchState : IState
{
    private BirdController bird;

    public BirdLaunchState(BirdController bird)
    {
        this.bird = bird;
    }

    public void Enter()
    {
    }

    public void ExecuteOnce()
    {
        // Run add force
    }

    public void ExecuteEveryFrame()
    {
        // Run Animation
    }

    public void Exit()
    {
    }
}