using System;
using DG.Tweening;
using UnityEngine;

public class UIPanel : MonoBehaviour, IUIShow, IUIHide
{
    [SerializeField] private EUIType UIType;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private float duration = 3f;
    [SerializeField] private Vector2 hidePos;

    private void Awake()
    {
        UIManager.Instance.OnUIChange += HandleUITypeChanged;
    }

    private void HandleUITypeChanged(EUIType newType, Action action)
    {
        if (newType == UIType)
            ShowUI();
        else
            HideUI(action);
    }

    public void HideUI(Action action)
    {
        rectTransform.DOLocalMove(hidePos, duration)
        .SetEase(Ease.InSine)
        .OnComplete(() => { gameObject.SetActive(false); action?.Invoke(); });
    }

    public void ShowUI()
    {
        gameObject.SetActive(true);
        rectTransform.localPosition = hidePos;
        rectTransform.DOLocalMove(Vector2.zero, duration);
    }
}
