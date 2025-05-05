using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Action<EUIType, Action, Action<UIPanel>> OnUIChange;
    public Action OnCloseAllUI;

    protected Stack<UIPanel> panelStack;
    protected EUIType currentType = EUIType.None;

    protected virtual void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);

        panelStack = new Stack<UIPanel>();
    }

    protected virtual void Start()
    {
    }

    protected void GetChildrenPanel(Transform parent)
    {
        foreach (Transform child in parent)
            OnUIChange += child.GetComponent<UIPanel>().HandleUITypeChanged;
    }

    public void ChangeUIType(EUIType newType)
    {
        if (currentType == newType && newType != EUIType.Back)
            return;

        EUIType previousState = currentType;
        currentType = newType;

        if (newType != EUIType.None && newType != EUIType.Back)
            OnUIChange?.Invoke(newType, null, AddPanelToStack);
        else if (newType != EUIType.Back)
            OnUIChange?.Invoke(newType, OnCloseAllUI, null);
        else
            BackToPrevious();
    }

    public void AddPanelToStack(UIPanel panel)
    {
        if (panel == null)
            return;
        if (panelStack == null)
            panelStack = new Stack<UIPanel>();

        panelStack.Push(panel);
    }

    public void RemoveFromStack(UIPanel panel)
    {
        if (panel == null || panelStack.Count == 0)
            return;

        if (panel != panelStack.Peek())
            return;

        panelStack.Pop();
    }

    public void CleartStack()
    {
        panelStack.Clear();
    }

    public void BackToPrevious()
    {
        if (panelStack.Count < 2)
        {
            Debug.LogWarning("stack is less than 2");
            return;
        }

        // Hide current panel
        var currentPanel = panelStack.Pop();
        currentPanel.HideUI(null);

        // Show prev panel
        panelStack.Peek().ShowUI(null);
    }
}
