using DG.Tweening;
using System;
using UnityEngine;

public class SwipeManager : MonoBehaviour, IUISwipe
{
    public static SwipeManager Instance { get; private set; }
    public Action<int, int> OnUpdateSwipeButton;
    public Action<int> OnUpdateNavigationBar;

    [Header("Swipe settings")]
    [SerializeField] private Ease easeType;
    [SerializeField] private float pageStep;
    [SerializeField] private float tweenTime;

    private RectTransform scrollViewContent;
    private Vector3 targetPos;
    private int currentPage = 1;
    private int maxPage;
    public Action<int> OnSwipePage;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }

    public void ContentRegister(RectTransform scrollViewContent)
    {
        this.scrollViewContent = scrollViewContent;
        targetPos = scrollViewContent.anchoredPosition;
        maxPage = scrollViewContent.childCount;
        CheckActieveSwipeButton();
    }

    public void Swipe()
    {
        scrollViewContent.DOLocalMove(targetPos, tweenTime).SetEase(easeType);
        CheckActieveSwipeButton();
    }

    public void CheckActieveSwipeButton()
    {
        OnUpdateSwipeButton?.Invoke(currentPage, maxPage);
        OnUpdateNavigationBar?.Invoke(currentPage);
    }

    public void Next()
    {
        if (currentPage < maxPage)
        {
            currentPage++;
            targetPos.x -= pageStep;
            Swipe();
        }
    }

    public void Previous()
    {
        if (currentPage > 1)
        {
            currentPage--;
            targetPos.x += pageStep;
            Swipe();
        }
    }
}
