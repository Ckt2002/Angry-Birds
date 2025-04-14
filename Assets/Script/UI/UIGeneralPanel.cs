using UnityEngine;

public class UIGeneralPanel : MonoBehaviour, IUIHide
{
    public void HideUI()
    {
        gameObject.SetActive(false);
    }
}