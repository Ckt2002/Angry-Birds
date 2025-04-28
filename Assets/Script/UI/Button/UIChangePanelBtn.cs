using UnityEngine;

public class UIChangePanelBtn : UIButton
{
    [SerializeField] private EUIType UITypeToChange;

    public override void Action()
    {
        UIManager.Instance?.ChangeUIType(UITypeToChange);
    }
}