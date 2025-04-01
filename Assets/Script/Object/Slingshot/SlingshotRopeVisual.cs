using UnityEngine;

public class SlingshotRopeVisual : MonoBehaviour
{
    [SerializeField] private Transform[] startPos;
    [SerializeField] private LineRenderer[] lineRenderers;
    private Vector2 readyPos;

    public void Initialize(Vector2 readyPos)
    {
        this.readyPos = readyPos;
        lineRenderers[0].SetPosition(0, startPos[0].position);
        lineRenderers[1].SetPosition(0, startPos[1].position);
        ResetRope();
    }

    public void UpdateRope(Vector2 birdPos)
    {
        Vector2 ropeEndPos = birdPos - (readyPos - birdPos).normalized * 0.8f;
        lineRenderers[0].SetPosition(1, ropeEndPos);
        lineRenderers[1].SetPosition(1, ropeEndPos);
    }

    public void ResetRope()
    {
        lineRenderers[0].SetPosition(1, startPos[1].position);
        lineRenderers[1].SetPosition(1, startPos[1].position);
    }
}