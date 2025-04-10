public interface IBirdState
{
    void Enter();
    void ExecuteOnce();
    void ExecuteEveryFrame();
    void Exit();
}