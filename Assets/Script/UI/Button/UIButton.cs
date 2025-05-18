using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour, IUIButton, IUIButtonClickEffect
    , IUIButtonMouseEnterEffect, IUIButtonMouseOutEffect
{
    protected Button button;
    protected SoundManager soundManager;

    protected virtual void Awake()
    {
        button = GetComponent<Button>();
    }

    protected virtual void Start()
    {
        soundManager = SoundManager.Instance;
        button?.onClick.AddListener(ClickEffect);
    }

    public virtual void ClickEffect()
    {
        soundManager.PlayUIAudio((int)EUIAudioClip.ButtonClick, false);

        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOScaleY(0.8f, 0.2f).OnComplete(() =>
        {
            transform.DOScaleY(1, 0.2f).SetEase(Ease.OutElastic).OnComplete(Action);
        }));
    }

    public virtual void Action()
    {
    }

    public virtual void MouseEnterEffect()
    {
        throw new System.NotImplementedException();
    }

    public virtual void MouseExitEffect()
    {
        throw new System.NotImplementedException();
    }

    protected void OnDestroy()
    {
        DOTween.KillAll(true);
    }
}
