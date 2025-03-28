using UnityEngine;

public class ShotSystem : MonoBehaviour
{
    [SerializeField] private float launchForce;
    [SerializeField] private float maxTension;

    private Slingshot slingshot;
    private Vector2 slingshotStartPos;
    private GameObject currentBird;
    private bool isDragging;

    private void Start()
    {
        slingshot = Slingshot.Instance;
        slingshotStartPos = slingshot.centerPos.position;
    }

    private void Update()
    {
        if (currentBird == null)
        {
            currentBird = BirdSystem.Instance.GetNextBird();
            if (currentBird == null)
            {
                Debug.LogError("You Lose");
                return;
            }

            currentBird.transform.position = slingshotStartPos;
        }

        MouseDragSystem();
        CheckMouseRelease();
    }

    private void MouseDragSystem()
    {
        if (Input.GetMouseButton(0))
        {
            var hit = Physics2D.Raycast(Camera.main!.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && currentBird != null && hit.collider.gameObject == currentBird)
                isDragging = true;
        }
    }

    private void CheckMouseRelease()
    {
        if (isDragging && Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            LaunchBird();
        }

        if (isDragging) DragBird();
    }

    private void DragBird()
    {
        Vector2 mousePos = Camera.main!.ScreenToWorldPoint(Input.mousePosition);

        var direction = (slingshotStartPos - mousePos).normalized;
        var distance = Vector2.Distance(mousePos, slingshotStartPos);
        distance = Mathf.Min(distance, maxTension);

        currentBird.transform.position = slingshotStartPos - direction * distance;
        slingshot.SetLinePos(currentBird.transform.position);
    }

    private void LaunchBird()
    {
        Vector2 birdPos = currentBird.transform.position;

        var direction = (slingshotStartPos - birdPos).normalized;

        var tension = Vector2.Distance(slingshotStartPos, birdPos);

        var birdComponent = currentBird.GetComponent<Bird>();
        birdComponent.Fly(direction * tension * launchForce);

        // currentBird = null;
        slingshot.ResetLinePos();
    }
}