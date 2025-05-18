using DG.Tweening;
using UnityEngine.EventSystems;

public class UINextBtn : UIButton, IPointerEnterHandler, IPointerExitHandler
{
    public override void Action()
    {
        base.Action();
        SceneSystem.Instance.NextLevel();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseEnterEffect();
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        MouseExitEffect();
    }

    public override void MouseEnterEffect()
    {
        transform.DOScale(1.2f, 0.5f);
    }

    public override void MouseExitEffect()
    {
        transform.DOScale(1f, 0.5f);
    }
}
