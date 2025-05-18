using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISoundBtn : UIButton, IPointerEnterHandler, IPointerExitHandler, IUIButtonShowEffect
{
    [SerializeField] private Image hideImg;
    private bool soundOn = true;

    public override void Action()
    {
        base.Action();
        var volume = 1f;
        if (soundOn)
            volume = 0f;
        soundOn = !soundOn;
        soundManager.SetSystemAudioVolume(volume);
        soundManager.SetUIAudioVolume(volume);

        var fadeValue = 1 - volume;
        fadeValue = Mathf.Min(fadeValue, 0.5f);
        hideImg.DOFade(fadeValue, 0.5f);
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
