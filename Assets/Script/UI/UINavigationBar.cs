using UnityEngine;
using UnityEngine.UI;

public class UINavigationBar : MonoBehaviour
{
    public Color disableColor;
    private Image[] images;
    private int currentIndex = 0;

    private void Start()
    {
        images = GetComponentsInChildren<Image>();
        SwipeManager.Instance.OnUpdateNavigationBar += UpdateButtons;
    }

    public void UpdateButtons(int currentPage)
    {
        currentIndex = currentPage - 1;
        images[currentIndex].color = Color.white;
        for (int i = 0; i < images.Length; i++)
            if (i != currentIndex)
                images[i].color = disableColor;
    }
}