using System;
using UnityEngine;

public class UITutorialPanel : InGameUIPanel
{
    [SerializeField] SOTutorial tutorialData;
    [SerializeField] private RectTransform scrollViewContent;
    [SerializeField] private RectTransform[] contentPages;

    private IUITutorialPage[] uITutorialPages;

    private void OnEnable()
    {
        SwipeManager.Instance.ContentRegister(scrollViewContent);
    }

    public override void ShowUI(Action<UIPanel> updateStackAct)
    {
        if (uITutorialPages == null)
        {
            uITutorialPages = new IUITutorialPage[tutorialData.tutorialData.Length];
            for (int i = 0; i < contentPages.Length; i++)
            {
                var data = tutorialData.tutorialData[i];
                var component = contentPages[i].GetComponent<IUITutorialPage>();

                if (component != null)
                    component.SetUpContent(data.image, data.description);
            }
        }

        base.ShowUI(updateStackAct);
    }
}