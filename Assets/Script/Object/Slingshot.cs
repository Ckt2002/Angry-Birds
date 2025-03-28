using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public static Slingshot Instance;

    [SerializeField] private float maxTension;
    [SerializeField] private LineRenderer[] lineRenderers;
    [SerializeField] private Transform[] startPos;
    [SerializeField] public Transform centerPos;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        lineRenderers[0].SetPosition(0, startPos[0].position);
        lineRenderers[1].SetPosition(0, startPos[1].position);
        ResetLinePos();
    }

    public void SetLinePos(Vector2 birdPos)
    {
        var middlePos = birdPos - ((Vector2)centerPos.position - birdPos).normalized * 0.8f;

        lineRenderers[0].SetPosition(1, middlePos);
        lineRenderers[1].SetPosition(1, middlePos);
    }

    public void ResetLinePos()
    {
        lineRenderers[0].SetPosition(1, startPos[1].position);
        lineRenderers[1].SetPosition(1, startPos[1].position);
    }
}