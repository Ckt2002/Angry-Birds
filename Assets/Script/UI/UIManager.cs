using System.Collections.Generic;
using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public Action<EUIType, Action, Action<UIPanel>> OnUIChange;
    public Action OnCloseAllUI;

    private IUIHide generalPanel;
    private Stack<UIPanel> panelStack;

    EUIType currentType = EUIType.None;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        panelStack = new Stack<UIPanel>();
    }

    private void Start()
    {
        generalPanel = GetComponentInChildren<IUIHide>(true);
        OnCloseAllUI += generalPanel.HideUI;
        Transform panelTransform = (generalPanel as Component)?.transform;
        foreach (Transform child in panelTransform)
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

        var currentPanel = panelStack.Pop();
        currentPanel.HideUI(null);
        panelStack.Peek().ShowUI(null);
    }
}
