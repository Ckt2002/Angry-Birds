using UnityEngine;
using UnityEngine.UI;

public class UITutorialContentPage : MonoBehaviour, IUITutorialPage
{
    [SerializeField] Image tutorialImg;
    [SerializeField] Text descriptionTxt;

    public void SetUpContent(Sprite sprite, string description)
    {
        tutorialImg.sprite = sprite;
        descriptionTxt.text = description;
    }
}
