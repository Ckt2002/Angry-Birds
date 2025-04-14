using UnityEngine;
using UnityEngine.UI;

public class UILoadSceneBtn : MonoBehaviour, IUILoadSceneBtn
{
    [SerializeField] private EScene sceneToLoad;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        button.onClick.AddListener(LoadScene);
    }

    public void LoadScene()
    {
        SceneSystem.Instance.LoadScene((int)sceneToLoad);
    }
}
