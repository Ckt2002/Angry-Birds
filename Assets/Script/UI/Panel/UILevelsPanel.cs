using DG.Tweening;
using System.Collections;
using UnityEngine;

public class UILevelsPanel : InGameUIPanel
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private RectTransform scrollViewContent;
    [SerializeField] private RectTransform[] contentPages;

    private LoadLevelManager loadLevelManager;
    private GameObject[] btnLst;
    private bool loaded = false;

    private void Start()
    {
    }

    private void OnEnable()
    {
        SwipeManager.Instance.ContentRegister(scrollViewContent);
    }

    protected override void ShowUIOnComplete()
    {
        base.ShowUIOnComplete();
        if (loadLevelManager == null)
            loadLevelManager = LoadLevelManager.Instance;

        var lst = loadLevelManager.levelManagerData.levelDataArr;
        StartCoroutine(LoadSlots(lst));
    }

    private IEnumerator LoadSlots(LevelData[] dataLst)
    {
        if (!loaded)
        {
            btnLst = new GameObject[dataLst.Length];
            int count = 0, pageInd = 0, i = 0;
            foreach (var data in dataLst)
            {
                if (count >= 6)
                {
                    pageInd++;
                    count = 0;
                }
                var slot = Instantiate(slotPrefab, contentPages[pageInd]);
                slot.transform.localScale = Vector3.zero;
                var comp = slot.GetComponent<UILoadLevelBtn>();
                comp.SetUpBtn(data.Level, data.IsLocked, data.StarNumber);
                btnLst[i++] = slot;
                yield return new WaitForSeconds(0.0003f);
                count++;
            }
            loaded = true;
        }
        else
            foreach (var btn in btnLst)
                btn.transform.localScale = Vector3.zero;

        foreach (var slot in btnLst)
        {
            slot.transform.DOScale(1, 1f).SetEase(Ease.OutElastic);
            yield return new WaitForSeconds(0.5f);
        }
    }
}