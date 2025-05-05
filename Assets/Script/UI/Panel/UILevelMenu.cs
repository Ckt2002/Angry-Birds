using DG.Tweening;
using System.Collections;
using UnityEngine;

public class UILevelMenu : MenuUIPanel
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotsParent;

    private bool loaded = false;
    private GameObject[] btnLst;

    protected override void ShowUIOnComplete()
    {
        base.ShowUIOnComplete();

        var lst = LoadLevelManager.Instance.levelManagerData.levelDataArr;
        StartCoroutine(LoadSlots(lst));
    }

    private IEnumerator LoadSlots(LevelData[] dataLst)
    {
        if (!loaded)
        {
            btnLst = new GameObject[dataLst.Length];
            int i = 0;
            foreach (var data in dataLst)
            {
                var slot = Instantiate(slotPrefab, slotsParent);
                slot.transform.localScale = Vector3.zero;
                var comp = slot.GetComponent<UILoadLevelBtn>();
                comp.SetUpBtn(data.Level, data.IsLocked, data.StarNumber);
                btnLst[i++] = slot;
                yield return new WaitForSeconds(0.0003f);
            }
            loaded = true;
        }
        else
            foreach (var btn in btnLst)
                btn.transform.localScale = Vector3.zero;

        foreach (var btn in btnLst)
        {
            btn.transform.DOScale(1, 1f).SetEase(Ease.OutElastic);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
