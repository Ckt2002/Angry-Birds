using DG.Tweening;
using System.Collections;
using UnityEngine;

public class UILevelsPanel : UIPanel
{
    private LoadLevelManager loadLevelManager;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotsParent;

    protected override void ShowUIComplete()
    {
        base.ShowUIComplete();
        if (loadLevelManager == null)
            loadLevelManager = LoadLevelManager.Instance;

        var lst = loadLevelManager.levelManagerData.levelDataArr;
        StartCoroutine(LoadSlots(lst));
    }

    private IEnumerator LoadSlots(LevelData[] dataLst)
    {
        var objLst = new GameObject[dataLst.Length];
        int i = 0;
        foreach (var data in dataLst)
        {
            var slot = Instantiate(slotPrefab, slotsParent);
            slot.transform.localScale = Vector3.zero;
            var comp = slot.GetComponent<UILoadLevelBtn>();
            comp.SetUpBtn(data.Level, data.IsLocked, data.StarNumber);
            objLst[i++] = slot;
            yield return new WaitForSeconds(0.0003f);
        }

        foreach (var slot in objLst)
        {
            slot.transform.DOScale(1, 1f).SetEase(Ease.OutElastic);
            yield return new WaitForSeconds(0.5f);
        }
    }
}