using System.Collections;
using UnityEngine;

public class TestBird : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private bool launched = false;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 launchForce)
    {
        if (launched)
            return;

        rb2D.bodyType = RigidbodyType2D.Dynamic;
        rb2D.AddForce(launchForce, ForceMode2D.Impulse);
        launched = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(HideBird());
    }

    private void OnEnable()
    {
        ResetBird();
    }

    private void ResetBird()
    {
        launched = false;
        rb2D.bodyType = RigidbodyType2D.Kinematic;
    }

    private IEnumerator HideBird()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
        ResetBird();
    }
}
