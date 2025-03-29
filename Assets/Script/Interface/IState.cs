public interface IState
{
    void Enter();
    void ExecuteOnce();
    void ExecuteEveryFrame();
    void Exit();
}