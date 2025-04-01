using UnityEngine;

public class SlingshotController : MonoBehaviour, IBirdReleaser
{
    [SerializeField] private Transform readyTransform;
    [SerializeField] private float maxTension;
    [SerializeField] private float launchForce = 10;
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
        launcher.SetValues(maxTension, launchForce, readyPos);
    }

    void Update()
    {
        if (currentBird == null)
        {
            currentBird = GetNexBird();
            currentBird.disableAction += ReleaseBird;
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
        #region Calculate
        Vector2 mousePos = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
        var direction = (readyPos - mousePos).normalized;
        var distance = Vector2.Distance(mousePos, readyPos);
        distance = Mathf.Min(distance, maxTension);

        currentBird.BirdDragState();
        currentBird.transform.position = readyPos - direction * distance;
        #endregion

        #region Call function
        ropeVisual.UpdateRope(currentBird.transform.position);
        #endregion
    }

    private void LaunchBird()
    {
        #region Calculate
        Vector2 birdPos = currentBird.transform.position;
        var direction = (readyPos - birdPos).normalized;
        var tension = Vector2.Distance(readyPos, birdPos);
        var birdComponent = currentBird.GetComponent<BirdController>();
        #endregion

        #region Call function
        birdComponent.BirdLaunchState(direction * tension * launchForce);
        ropeVisual.ResetRope();
        #endregion
    }

    public void ReleaseBird()
    {
        if (currentBird != null)
        {
            currentBird.disableAction -= ReleaseBird;
            currentBird = null;
        }
    }
}