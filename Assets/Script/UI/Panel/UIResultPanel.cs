using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class UIResultPanel : UIPanel
{
    private int resultStar;
    private IUIStar[] stars;
    private ResultSystem resultSystem;
    [SerializeField] private GameObject starsParent;

    public override void ShowUI(Action<UIPanel> updateStackAct)
    {
        gameObject.SetActive(true);
        Initialization();
        foreach (var star in stars)
        {
            star.Hide();
        }
        rectTransform.DOLocalMove(Vector2.zero, 1.5f)
            .SetLink(gameObject)
            .OnComplete(
            () =>
            {
                StartCoroutine(ShowStars());
                updateStackAct?.Invoke(this);
            });
    }

    private void Initialization()
    {
        rectTransform.localPosition = hidePos;
        stars = starsParent.GetComponentsInChildren<UIStar>();
        resultSystem = ResultSystem.Instance;
        resultStar = resultSystem.resultStar;
    }

    private IEnumerator ShowStars()
    {
        EStarType starType;
        foreach (var star in stars)
        {
            if (resultStar > 0)
            {
                starType = EStarType.FillStar;
                resultStar--;
            }
            else
                starType = EStarType.EmptyStar;

            star.SetStar(starType);
            star.Show(null);
            yield return new WaitForSeconds(0.8f);
        }
    }
}
