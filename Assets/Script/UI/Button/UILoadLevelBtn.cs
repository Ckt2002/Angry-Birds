using UnityEngine;
using UnityEngine.UI;

public class UILoadLevelBtn : UIButton
{
    [SerializeField] private Image lockIcon;
    [SerializeField] private Text levelText;
    [SerializeField] private Image[] starIcons;
    [SerializeField] private Sprite[] starSprites;

    private int level = 1;
    //private int starNumber = 0;
    private bool levelLocked = true;

    protected override void Start()
    {
        base.Start();
    }

    public void SetUpBtn(int level, bool locked, int starNumber = 0)
    {
        this.level = level;
        levelText.text = level.ToString();
        levelLocked = locked;
        lockIcon.gameObject.SetActive(locked);

        int i = 0;

        for (; i < starNumber; i++)
            starIcons[i].sprite = starSprites[0];

        for (; i < starIcons.Length; i++)
            starIcons[i].sprite = starSprites[1];
    }

    public override void Action()
    {
        base.Action();
        if (levelLocked)
            return;

        SoundManager.Instance.StopSystemAudio();
        SceneSystem.Instance.LoadLevel(level);
    }
}
