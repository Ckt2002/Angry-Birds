using System;
using DG.Tweening;
using UnityEngine;

public class UIResultPanel : UIPanel
{
    [SerializeField] private GameObject[] stars;
    [Header("Star Animation Settings")]
    [SerializeField] private float baseDuration = 0.5f;
    [SerializeField] private float delayBetweenStars = 0.1f;
    [SerializeField] private Ease scaleEase = Ease.OutBack;
    [SerializeField] private float bounceHeight = 30f;
    [SerializeField] private float rotationAmount = 15f;

    private void Start()
    {

        Debug.Log(stars.Length);
        Debug.Log(stars[0].GetComponent<RectTransform>().localScale);

    }

    public override void ShowUI(Action<UIPanel> updateStackAct)
    {
        gameObject.SetActive(true);
        //foreach (var star in stars)
        //{
        //    star.localScale = Vector3.zero;
        //}
        rectTransform.localPosition = hidePos;
        rectTransform.DOLocalMove(Vector2.zero, duration)
            .SetLink(gameObject)
            .OnComplete(
            () =>
            {
                ShowStars();
                updateStackAct?.Invoke(this);
            });
    }

    private void ShowStars()
    {
        Debug.Log("Running here");
        //foreach (var star in stars)
        //{
        //    star.localScale = Vector3.zero;
        //}
        //if (stars == null || stars.Length == 0)
        //{
        //    Debug.LogWarning("Stars array is not properly assigned!");
        //    return;
        //}

        //foreach (var star in stars)
        //{
        //    star.DOScale(Vector3.zero, 5f);
        //}

        //Sequence masterSequence = DOTween.Sequence();
        //for (int i = 0; i < stars.Length; i++)
        //{
        //    RectTransform star = stars[i];

        //    // Create individual star sequence
        //    Sequence starSequence = DOTween.Sequence();

        //    // Scale animation
        //    starSequence.Append(star.DOScale(Vector3.one, baseDuration)
        //        .SetEase(scaleEase));

        //    // Bounce animation (optional)
        //    Vector3 originalPos = star.localPosition;
        //    starSequence.Join(star.DOLocalMoveY(originalPos.y + bounceHeight, baseDuration * 0.5f)
        //        .SetEase(Ease.OutQuad)
        //        .SetLoops(2, LoopType.Yoyo));

        //    // Rotation animation (optional)
        //    starSequence.Join(star.DOLocalRotate(new Vector3(0, 0, rotationAmount), baseDuration * 0.75f)
        //        .SetEase(Ease.InOutSine)
        //        .SetLoops(2, LoopType.Yoyo));

        //    // Add delay based on star index
        //    masterSequence.Insert(i * delayBetweenStars, starSequence);
        //}

        //// Additional effects on complete if needed
        //masterSequence.OnComplete(() =>
        //{
        //    // Optional: Add continuous pulsing animation
        //    foreach (var star in stars)
        //    {
        //        star.DOPunchScale(Vector3.one * 0.1f, 0.5f, 1, 0.5f)
        //            .SetLoops(-1, LoopType.Yoyo)
        //            .SetDelay(UnityEngine.Random.Range(0f, 1f));
        //    }
        //});
    }
}
