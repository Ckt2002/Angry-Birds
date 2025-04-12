using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public Action<EUIType, Action> OnUIChange;
    public Action OnGeneralPanelChange;

    EUIType currentType = EUIType.None;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void ChangeUIType(EUIType newType)
    {
        if (currentType == newType)
            return;

        EUIType previousState = currentType;
        currentType = newType;

        if (newType != EUIType.None)
            OnUIChange?.Invoke(newType, null);
        else
            OnUIChange?.Invoke(newType, OnGeneralPanelChange);
    }
}