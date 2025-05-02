public class UIResetBtn : UIButton
{
    public override void Action()
    {
        SceneSystem.Instance.RestartLevel();
    }
}
