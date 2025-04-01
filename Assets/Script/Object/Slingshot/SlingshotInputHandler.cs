using System;
using UnityEngine;

public class SlingshotInputHandler : MonoBehaviour
{
    public event Action OnDragAction;
    public event Action OnReleaseAction;
    private bool isDragging = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                isDragging = true;
                OnDragAction?.Invoke();
            }
        }

        if (isDragging && Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            OnReleaseAction?.Invoke();
        }

        if (isDragging) OnDragAction?.Invoke();
    }
}