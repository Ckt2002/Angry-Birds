using UnityEngine;

public class ResultSystem : MonoBehaviour
{
    public static ResultSystem Instance;

    public int resultStar = 0;

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

    public void SetResultRequires(int fullStar, int twoStar, int oneStar)
    {
        requireFullStar = fullStar;
        requireTwoStar = twoStar;
        requireOneStar = oneStar;
    }

    private void LateUpdate()
    {
        CheckResult();
    }

    public void CheckResult()
    {
        if (objectsActivation.enemiesRemain > 0)
        {
            if (objectsActivation.birdsRemain == 0)
            {
                //Debug.Log("Opening result UI");
                resultStar = 0;
                ShowResult();
            }
        }
        else
        {
            //Debug.Log("Opening result UI");
            if (objectsActivation.birdsRemain >= requireFullStar)
            {
                resultStar = 3;
            }
            else if (objectsActivation.birdsRemain >= requireTwoStar)
            {
                resultStar = 2;
            }
            else if (objectsActivation.birdsRemain >= requireOneStar)
            {
                resultStar = 1;
            }
            else
                resultStar = 0;
            ShowResult();
        }
    }

    private void ShowResult()
    {
        //Debug.Log("Opening result UI");

        UIManager.Instance.ShowInGameMenuPanel();
        UIManager.Instance.ChangeUIType(EUIType.Result);
    }
}
