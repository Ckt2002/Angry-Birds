using DG.Tweening;
using System;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    [SerializeField] protected EUIType UIType;

    public void HandleUITypeChanged(EUIType newType, Action closeGeneralPanelAct, Action<UIPanel> updateStackAct)
    {
        if (newType == UIType)
            ShowUI(updateStackAct);
        else
            HideUI(closeGeneralPanelAct);
    }

    public virtual void HideUI(Action closeGeneralPanelAct)
    {
    }

    protected virtual void HideUIOnComplete()
    {
        gameObject.SetActive(false);
    }

    public virtual void ShowUI(Action<UIPanel> updateStackAct)
    {
        SoundManager.Instance.PlayUIAudio((int)EUIAudioClip.PanelAppear, false);
    }

    protected virtual void ShowUIOnComplete()
    {
    }

    protected void OnDestroy()
    {
        DOTween.KillAll(true);
    }
}
