using System;
using DG.Tweening;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    [SerializeField] private EUIType UIType;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private float duration = 3f;
    [SerializeField] private Vector2 hidePos;

    public void HandleUITypeChanged(EUIType newType, Action closeGeneralPanelAct, Action<UIPanel> updateStackAct)
    {
        if (newType == UIType)
            ShowUI(updateStackAct);
        else
            HideUI(closeGeneralPanelAct);
    }

    public void HideUI(Action closeGeneralPanelAct)
    {
        rectTransform.DOLocalMove(hidePos, 0.5f)
            .SetEase(Ease.InSine)
            .SetLink(gameObject)
            .OnComplete(() =>
            {
                gameObject.SetActive(false);
                closeGeneralPanelAct?.Invoke();
            });
    }

    public void ShowUI(Action<UIPanel> updateStackAct)
    {
        gameObject.SetActive(true);
        rectTransform.localPosition = hidePos;
        rectTransform.DOLocalMove(Vector2.zero, duration)
            .SetLink(gameObject)
            .OnComplete(
            () =>
            {
                updateStackAct?.Invoke(this);
            });
    }
}
