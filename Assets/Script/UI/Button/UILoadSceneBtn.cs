using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class UILoadSceneBtn : UIButton, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private EScene sceneToLoad;

    public override void Action()
    {
        base.Action();
        SceneSystem.Instance?.LoadScene((int)sceneToLoad);
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
