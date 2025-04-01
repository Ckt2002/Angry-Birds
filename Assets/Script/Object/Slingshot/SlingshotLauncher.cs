using UnityEngine;

public class SlingshotLauncher : MonoBehaviour
{
    private float maxTension;
    private float launchForce;
    private Vector2 readyPos;

    public void SetValues(float maxTension, float launchForce, Vector2 readyPos)
    {
        this.maxTension = maxTension;
        this.launchForce = launchForce;
        this.readyPos = readyPos;
    }

    public Vector2 CalculateLaunchForce(Vector2 birdPos)
    {
        Vector2 direction = (readyPos - birdPos).normalized;
        float tension = Mathf.Min(Vector2.Distance(readyPos, birdPos), maxTension);
        return direction * tension * launchForce;
    }

    public Vector2 CalculateBirdPosition(Vector2 mousePos)
    {
        Vector2 direction = (readyPos - mousePos).normalized;
        float distance = Mathf.Min(Vector2.Distance(mousePos, readyPos), maxTension);
        return readyPos - direction * distance;
    }
}