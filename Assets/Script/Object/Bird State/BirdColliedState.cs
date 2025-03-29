public class BirdColliedState : IState
{
    private readonly BirdController bird;

    public BirdColliedState(BirdController bird)
    {
        this.bird = bird;
    }

    public void Enter()
    {
    }

    public void ExecuteOnce()
    {
    }

    public void ExecuteEveryFrame()
    {
    }

    public void Exit()
    {
    }
}