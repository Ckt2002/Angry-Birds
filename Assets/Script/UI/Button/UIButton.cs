using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour, IUIButton, IUIButtonClickEffect
    , IUIButtonMouseEnterEffect, IUIButtonMouseOutEffect
{
    protected Button button;

    protected virtual void Awake()
    {
        button = GetComponent<Button>();
    }

    protected virtual void Start()
    {
        button?.onClick.AddListener(ClickEffect);
    }

    public virtual void ClickEffect()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOScaleY(0.8f, 0.2f).OnComplete(() =>
        {
            transform.DOScaleY(1, 0.5f).SetEase(Ease.OutElastic).OnComplete(Action);
        }));
    }

    public virtual void Action()
    {
        Debug.Log("Action");
    }

    public virtual void MouseEnterEffect()
    {
        throw new System.NotImplementedException();
    }

    public virtual void MouseExitEffect()
    {
        throw new System.NotImplementedException();
    }
}
