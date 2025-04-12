using UnityEngine;
using UnityEngine.UI;

public class UIChangePanelBtn : MonoBehaviour, IUIChangePanelBtn
{
    [SerializeField] private EUIType UIType;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        button.onClick.AddListener(ChangeUIType);
    }

    public void ChangeUIType()
    {
        Debug.Log("Clicked");
        UIManager.Instance.ChangeUIType(UIType);
    }
}