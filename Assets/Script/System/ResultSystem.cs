using System.IO;
using UnityEngine;

public class ResultSystem : MonoBehaviour
{
    public static ResultSystem Instance;
    public int resultStar { get; private set; } = 0;

    private ObjectsActivation objectsActivation;
    private int requireFullStar;
    private int requireTwoStar;
    private int requireOneStar;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        objectsActivation = ObjectsActivation.Instance;
    }

    public void SetResultRequires(int oneStar, int twoStar, int fullStar)
    {
        requireOneStar = oneStar;
        requireTwoStar = twoStar;
        requireFullStar = fullStar;
    }

    public void CheckResult()
    {
        if (objectsActivation.enemiesRemain > 0)
        {
            if (objectsActivation.birdsRemain == 0)
            {
                resultStar = 0;
                ShowResult();
            }
        }
        else
        {
            if (objectsActivation.birdsRemain >= requireFullStar)
                resultStar = 3;
            else if (objectsActivation.birdsRemain >= requireTwoStar)
                resultStar = 2;
            else
                resultStar = 1;

            UpdateLevelManager();
            ShowResult();
        }
    }

    private void ShowResult()
    {
        var inGameUI = UIManager.Instance as InGameUIManager;
        if (inGameUI != null)
            inGameUI.ShowInGameMenuPanel();

        UIManager.Instance.ChangeUIType(EUIType.Result);
    }

    private void UpdateLevelManager()
    {
        var currentLevel = LevelSystem.Instance.GetLevel;
        var lst = LoadLevelManager.Instance.levelManagerData.levelDataArr;

        if (lst[currentLevel - 1].StarNumber < resultStar)
            lst[currentLevel - 1].StarNumber = resultStar;

        // Unlock next level
        if (currentLevel < GameStat.Instance.maxLevel)
            lst[currentLevel].IsLocked = false;

        // Write to file
        var levelData = LoadLevelManager.Instance.levelManagerData;

        var json = JsonUtility.ToJson(levelData, true);
        var fileName = $"Level manager.json";
        string directoryPath = Path.Combine(Application.dataPath, "Data", "Level Manager");
        string fullPath = Path.Combine(directoryPath, fileName);
        File.WriteAllText(fullPath, json);
    }
}
