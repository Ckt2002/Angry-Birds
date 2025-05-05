using UnityEngine;

public class InGameUIManager : UIManager
{
    [SerializeField] private GameObject inGameMenuPanel;
    private IUIHide generalPanel;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        generalPanel = GetComponentInChildren<IUIHide>(true);
        OnCloseAllUI += generalPanel.HideUI;
        Transform parentPanel = (generalPanel as Component)?.transform;
        GetChildrenPanel(parentPanel);
    }

    public void ShowInGameMenuPanel()
    {
        inGameMenuPanel?.SetActive(true);
    }
}
