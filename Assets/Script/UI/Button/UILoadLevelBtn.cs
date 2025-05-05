using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILoadLevelBtn : UIButton
{
    [SerializeField] private Image lockIcon;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private Image[] starIcons;
    [SerializeField] private Sprite[] starSprites;

    private int level = 1;
    //private int starNumber = 0;
    private bool levelLocked = true;

    protected override void Start()
    {
        base.Start();
    }

    public void ShowButton()
    {
        transform.localScale = Vector3.zero;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(1.2f, 0.5f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            transform.DOScale(1, 0.5f).SetEase(Ease.OutBounce);
        }));
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
        if (levelLocked)
            return;

        SceneSystem.Instance.LoadLevel(level);
    }
}
