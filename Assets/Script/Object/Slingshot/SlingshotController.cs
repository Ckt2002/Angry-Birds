using System.Collections;
using UnityEngine;

public class SlingshotController : MonoBehaviour
{
    [SerializeField] private Transform readyTransform;
    [SerializeField] private SlingshotRopeVisual ropeVisual;
    [SerializeField] private SlingshotInputHandler inputHandler;
    [SerializeField] private SlingshotLauncher launcher;

    private BirdProviderSystem birdProviderSystem;
    private Vector2 readyPos;
    private BirdController currentBird;
    private bool isDragging = false;

    private void Start()
    {
        birdProviderSystem = BirdProviderSystem.Instance;
        readyPos = readyTransform.position;

        ropeVisual.Initialize(readyPos);
    }

    void Update()
    {
        if (currentBird == null)
        {
            currentBird = GetNexBird();
            if (currentBird != null)
                currentBird.BirdGetReadyState(readyPos);
        }

        if (Input.GetMouseButtonDown(0))
        {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                isDragging = true;
                DragBird();
            }
        }

        if (isDragging && Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            LaunchBird();
        }

        if (isDragging)
            DragBird();
    }

    public BirdController GetNexBird()
    {
        if (birdProviderSystem == null)
            birdProviderSystem = BirdProviderSystem.Instance;

        var bird = birdProviderSystem?.GetBirdFromList();
        return bird;
    }
    public Vector2 CalculateBirdPosition(Vector2 mousePos)
    {
        Vector2 direction = (readyPos - mousePos).normalized;
        float distance = Mathf.Min(Vector2.Distance(mousePos, readyPos), 2);
        return readyPos - direction * distance;
    }

    private void DragBird()
    {
        if (currentBird == null)
            return;

        Vector2 mousePos = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
        currentBird.BirdDragState();
        currentBird.transform.position = CalculateBirdPosition(mousePos);
        ropeVisual.UpdateRope(currentBird.transform.position);
    }

    public Vector2 CalculateLaunchForce(Vector2 birdPos)
    {
        Vector2 direction = (readyPos - birdPos).normalized;
        float tension = Mathf.Min(Vector2.Distance(readyPos, birdPos), 2);
        return direction * 10 * tension;
    }

    private void LaunchBird()
    {
        if (currentBird == null)
            return;
        Vector2 birdPos = currentBird.transform.position;
        var launchForceFinal = CalculateLaunchForce(birdPos);
        currentBird.GetComponent<BirdController>().BirdLaunchState(launchForceFinal);
        ropeVisual.ResetRope();
        StartCoroutine(GetNextBird());
    }

    private IEnumerator GetNextBird()
    {
        yield return new WaitForSeconds(3f);
        currentBird = null;
    }
}