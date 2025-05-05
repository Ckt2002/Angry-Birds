using UnityEngine;

public class MainMenuUIManager : UIManager
{

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        Transform parentPanel = transform;
        GetChildrenPanel(parentPanel);
    }
}
