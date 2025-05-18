using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIResultPanel : InGameUIPanel
{
    [SerializeField] private GameObject starsParent;
    [SerializeField] private Text title;
    [SerializeField] private static string winTitle = "Level Cleared";
    [SerializeField] private static string loseTitle = "Failure";
    [SerializeField] private GameObject winBtnGroup;
    [SerializeField] private GameObject loseBtnGroup;
    [SerializeField] private GameObject completeGameBtnGroup;

    private int resultStar;
    private IUIStar[] stars;
    private ResultSystem resultSystem;

    public override void ShowUI(Action<UIPanel> updateStackAct)
    {
        if (LevelSystem.Instance.GetLevel == GameStat.Instance.maxLevel)
        {
            SoundManager.Instance.PlaySystemAudio((int)ESystemAudioClip.GameComplete, false);
        }
        else
        {
            SoundManager.Instance.PlayUIAudio((int)EUIAudioClip.LevelComplete, false);
        }

        gameObject.SetActive(true);
        Initialization();
        foreach (var star in stars)
        {
            star.Hide();
        }
        LoadButtons();
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

        if (resultStar == 0)
            title.text = loseTitle;
        else
            title.text = winTitle;
    }

    private void LoadButtons()
    {
        if (LevelSystem.Instance.GetLevel == GameStat.Instance.maxLevel)
        {
            winBtnGroup.SetActive(false);
            loseBtnGroup.SetActive(false);
            completeGameBtnGroup.SetActive(true);
            return;
        }

        if (resultStar == 0)
        {
            winBtnGroup.SetActive(false);
            loseBtnGroup.SetActive(true);
            completeGameBtnGroup.SetActive(false);
        }
        else
        {
            winBtnGroup.SetActive(true);
            loseBtnGroup.SetActive(false);
            completeGameBtnGroup.SetActive(false);
        }
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
