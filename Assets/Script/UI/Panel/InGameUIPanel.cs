using DG.Tweening;
using System;
using UnityEngine;

public class InGameUIPanel : UIPanel
{
    [SerializeField] protected RectTransform rectTransform;
    [SerializeField] protected Vector2 hidePos = new Vector2(0, 1000);

    public override void ShowUI(Action<UIPanel> updateStackAct)
    {
        base.ShowUI(updateStackAct);
        ShowAnimation(updateStackAct);
    }

    protected virtual void ShowAnimation(Action<UIPanel> updateStackAct)
    {
        gameObject.SetActive(true);
        rectTransform.localPosition = hidePos;
        rectTransform.DOLocalMove(Vector2.zero, 1.5f)
            .SetLink(gameObject)
            .OnComplete(
            () =>
            {
                ShowUIOnComplete();
                updateStackAct?.Invoke(this);
            });
    }

    protected override void ShowUIOnComplete()
    {
        base.ShowUIOnComplete();
    }

    public override void HideUI(Action closeGeneralPanelAct)
    {
        base.HideUI(closeGeneralPanelAct);
        HideAnimation(closeGeneralPanelAct);
    }

    protected virtual void HideAnimation(Action closeGeneralPanelAct)
    {
        rectTransform.DOLocalMove(hidePos, 0.5f)
            .SetEase(Ease.InSine)
            .SetLink(gameObject)
            .OnComplete(() =>
            {
                HideUIOnComplete();
                closeGeneralPanelAct?.Invoke();
            });
    }

    protected override void HideUIOnComplete()
    {
        base.HideUIOnComplete();
    }
}
