using System;

public interface IUIHidePanel
{
    void HideUI(Action closeGeneralPanelAct, Action<UIPanel> updateStackAct);
}
