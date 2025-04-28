public class UINextBtn : UIButton
{
    private LevelSystem levelSystem;

    protected override void Awake()
    {
        base.Awake();
        levelSystem = LevelSystem.Instance;
    }

    public override void Action()
    {
        SceneSystem.Instance.LoadLevel();
    }
}
