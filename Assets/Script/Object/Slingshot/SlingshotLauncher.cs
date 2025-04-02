using UnityEngine;

public class SlingshotLauncher : MonoBehaviour
{

    [SerializeField] private float maxTension = 10f;
    [SerializeField] private float launchForce = 5f;
    private Vector2 readyPos;

    public void SetValues(Vector2 readyPos)
    {
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