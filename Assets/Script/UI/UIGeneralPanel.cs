using UnityEngine;

public class UIGeneralPanel : MonoBehaviour
{
    private void Awake()
    {
        UIManager.Instance.OnGeneralPanelChange += HideUI;
    }

    // private void HandleUITypeChanged(EUIType newType)
    // {
    //     if (newType != EUIType.None)
    //         ShowUI();
    // }

    private void ShowUI()
    {
        gameObject.SetActive(true);
    }

    private void HideUI()
    {
        gameObject.SetActive(false);
    }
}