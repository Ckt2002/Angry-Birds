using System.Collections;
using UnityEngine;

public class SlingshotController : MonoBehaviour
{
    [SerializeField] private Transform readyTransform;
    [SerializeField] private SlingshotRopeVisual ropeVisual;
    [SerializeField] private SlingshotInputHandler inputHandler;
    [SerializeField] private SlingshotLauncher launcher;

    private BirdProviderSystem slingshotSystem;
    private Vector2 readyPos;
    private BirdController currentBird;

    private void Start()
    {
        slingshotSystem = BirdProviderSystem.Instance;
        readyPos = readyTransform.position;

        ropeVisual.Initialize(readyPos);

        inputHandler.OnDragAction += DragBird;
        inputHandler.OnReleaseAction += LaunchBird;
        launcher.SetValues(readyPos);
    }

    void Update()
    {
        if (currentBird == null)
        {
            currentBird = GetNexBird();
            if (currentBird != null)
                currentBird.BirdGetReadyState(readyPos);
        }
    }

    public BirdController GetNexBird()
    {
        if (slingshotSystem == null)
            slingshotSystem = BirdProviderSystem.Instance;
        return slingshotSystem.GetBirdFromQueue();
    }

    private void DragBird()
    {
        if (currentBird == null)
            return;

        Vector2 mousePos = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
        //if (mousePos == (Vector2)currentBird.transform.position)
        //{
        currentBird.BirdDragState();
        currentBird.transform.position = launcher.CalculateBirdPosition(mousePos);
        ropeVisual.UpdateRope(currentBird.transform.position);
        //}
    }

    private void LaunchBird()
    {
        if (currentBird == null)
            return;
        Vector2 birdPos = currentBird.transform.position;
        var launchForceFinal = launcher.CalculateLaunchForce(birdPos);
        var birdComponent = currentBird.GetComponent<BirdController>();
        birdComponent.BirdLaunchState(launchForceFinal);
        ropeVisual.ResetRope();
        currentBird = null;
        //StartCoroutine(nameof(DisableCurrentBird));
    }

    private IEnumerator DisableCurrentBird()
    {
        yield return new WaitForSeconds(2f);
        if (currentBird != null)
            currentBird = null;
    }
}