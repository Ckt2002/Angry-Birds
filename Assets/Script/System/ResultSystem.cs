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
            else if (objectsActivation.birdsRemain >= requireOneStar)
                resultStar = 1;
            else
                resultStar = 0;

            ShowResult();
        }
    }

    private void ShowResult()
    {
        UIManager.Instance.ShowInGameMenuPanel();
        UIManager.Instance.ChangeUIType(EUIType.Result);
    }
}
