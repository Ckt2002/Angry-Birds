using System;

public class BirdColliedState : IState
{
    private BirdController bird;
    private Action disableAction;

    public BirdColliedState(BirdController bird, Action disableAction = null)
    {
        this.bird = bird;
        this.disableAction = disableAction;
    }

    public void Enter()
    {
    }

    public void ExecuteOnce()
    {
        disableAction.Invoke();
    }

    public void ExecuteEveryFrame()
    {
    }

    public void Exit()
    {
        bird = null;
        disableAction = null;
    }
}