using UnityEngine;

public class UILoadSceneBtn : UIButton
{
    [SerializeField] private EScene sceneToLoad;

    public override void Action()
    {
        SceneSystem.Instance.LoadScene((int)sceneToLoad);
    }
}
