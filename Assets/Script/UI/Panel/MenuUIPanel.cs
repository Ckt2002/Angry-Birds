using System;

public class MenuUIPanel : UIPanel
{
    private IUIButtonShowEffect[] buttons;

    private void Start()
    {
        if (UIType == EUIType.Menu)
            UIManager.Instance?.AddPanelToStack(this);

        buttons = GetComponentsInChildren<IUIButtonShowEffect>();
    }

    public override void ShowUI(Action<UIPanel> updateStackAct)
    {
        ShowUIOnComplete();
        updateStackAct?.Invoke(this);
    }

    protected override void ShowUIOnComplete()
    {
        gameObject.SetActive(true);
        if (buttons == null || buttons.Length == 0)
            buttons = GetComponentsInChildren<IUIButtonShowEffect>();

        foreach (var button in buttons)
        {
            button.ShowEffect();
        }
    }

    public override void HideUI(Action closeGeneralPanelAct)
    {
        HideUIOnComplete();
        closeGeneralPanelAct?.Invoke();
    }

    protected override void HideUIOnComplete()
    {
        base.HideUIOnComplete();
    }
}
