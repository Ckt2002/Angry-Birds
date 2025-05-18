using UnityEngine;

public class UISwipeBtn : UIButton
{
    [SerializeField] private ESwipeType swipeType;
    private SwipeManager swipeManager;

    protected override void Start()
    {
        base.Start();
        swipeManager = SwipeManager.Instance;
        swipeManager.OnUpdateSwipeButton += ActiveButton;
    }

    public override void Action()
    {
        if (swipeType == ESwipeType.Next)
            swipeManager.Next();
        else
            swipeManager.Previous();
    }

    public void ActiveButton(int currentPage, int maxPage)
    {
        if (swipeType == ESwipeType.Next)
        {
            if (currentPage == maxPage)
                button.interactable = false;
            else
                button.interactable = true;
        }
        else
        {
            if (currentPage == 1)
                button.interactable = false;
            else
                button.interactable = true;
        }
    }
}