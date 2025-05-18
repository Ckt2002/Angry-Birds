using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIQuitBtn : UIButton, IPointerEnterHandler, IPointerExitHandler, IUIButtonShowEffect
{
    public override void Action()
    {
        base.Action();
        Application.Quit();
    }

    public override void MouseEnterEffect()
    {
        transform.DOScale(1.2f, 0.5f);
    }

    public override void MouseExitEffect()
    {
        transform.DOScale(1f, 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MouseExitEffect();
    }

    public void ShowEffect()
    {
        transform.localScale = Vector2.zero;
        transform.DOScale(1f, 1f).SetEase(Ease.OutElastic);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        MouseEnterEffect();
    }
}
