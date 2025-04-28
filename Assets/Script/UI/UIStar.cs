using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIStar : MonoBehaviour, IUIStar
{
    private Image starImg;
    public Sprite[] starSprites;

    private void Awake()
    {
        starImg = GetComponent<Image>();
    }

    public void Hide()
    {
        var colorTemp = starImg.color;
        colorTemp.a = 0;
        starImg.color = colorTemp;
        transform.localScale = Vector3.zero;
    }

    public void SetStar(EStarType starType)
    {
        starImg.sprite = starSprites[(int)starType];
    }

    public void Show(Action action)
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(starImg.DOFade(1, 1f));

        sequence.Join(
            transform.DOScale(1.2f, 1f)
            .SetEase(Ease.OutBack)
            .OnComplete(() =>
            {
                transform.DOScale(1, 0.3f).SetEase(Ease.OutElastic);
            })
            );

        sequence.Join(
            transform.DORotate(new Vector3(0, 0, -360), 1f, RotateMode.FastBeyond360).SetEase(Ease.OutQuad)
            );

        if (action != null)
        {
            action.Invoke();
        }
    }
}
