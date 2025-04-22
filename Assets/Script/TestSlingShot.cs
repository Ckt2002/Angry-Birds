using System.Collections;
using UnityEngine;

public class TestSlingShot : MonoBehaviour
{
    [SerializeField] private GameObject bird;
    [SerializeField] private float maxTension = 10f;
    [SerializeField] private float launchForce = 5f;

    [SerializeField] private Vector2 readyPos;
    private GameObject currentBird;
    private bool isDragging = false;

    void Start()
    {
        readyPos = transform.position;
    }

    void Update()
    {
        if (currentBird == null)
        {
            var bird = BirdProviderSystem.Instance?.GetBirdFromQueue();
            //bird.BirdGetReadyState(transform.position);
            currentBird = bird?.gameObject;
            currentBird.transform.position = readyPos;
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

        if (isDragging) DragBird();
    }

    public Vector2 CalculateLaunchForce(Vector2 birdPos)
    {
        Vector2 direction = (readyPos - birdPos).normalized;
        return direction * launchForce * maxTension;
    }

    public Vector2 CalculateBirdPosition(Vector2 mousePos)
    {
        Vector2 direction = (readyPos - mousePos).normalized;
        float distance = Mathf.Min(Vector2.Distance(mousePos, readyPos), maxTension);
        return readyPos - direction * distance;
    }

    private void DragBird()
    {
        if (currentBird == null)
            return;

        Vector2 mousePos = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
        currentBird.transform.position = CalculateBirdPosition(mousePos);
    }

    private void LaunchBird()
    {
        if (currentBird == null)
            return;
        Vector2 birdPos = currentBird.transform.position;
        var launchForceFinal = CalculateLaunchForce(birdPos);
        currentBird.GetComponent<BirdController>().BirdLaunchState(launchForceFinal);
        StartCoroutine(Getnew());
    }

    private IEnumerator Getnew()
    {
        yield return new WaitForSeconds(3f);
        currentBird = null;
    }
}
