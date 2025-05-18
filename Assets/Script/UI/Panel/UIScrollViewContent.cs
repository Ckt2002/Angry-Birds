using UnityEngine;
using UnityEngine.EventSystems;

public class UIScrollViewContent : MonoBehaviour, IEndDragHandler
{
    private SwipeManager swipeManager;

    private void Start()
    {
        swipeManager = SwipeManager.Instance;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.position.x - eventData.pressPosition.x) > 1)
        {
            if (eventData.position.x > eventData.pressPosition.x)
                swipeManager.Previous();
            else
                swipeManager.Next();
        }
        else
            swipeManager.Swipe();
    }
}
