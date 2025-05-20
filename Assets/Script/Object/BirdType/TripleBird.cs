using System.Collections;
using UnityEngine;

public class TripleBird : BirdController
{
    [SerializeField] private float spreadAngle = 30f;
    [SerializeField] private float splitForce = 2f;
    protected override void SpecialSkill()
    {
        var baseVelocity = rb2D.linearVelocity;
        var particle = ParticlePoolingSystem.Instance.GetParticle(name);
        particle?.RunParticle(transform.position);
        soundManager.PlaySFXAudioOneShot((int)ESFXAudioClip.BirdSkill);
        anim?.RunSpecialSkill();

        var bird1 = CreateBird(spreadAngle, baseVelocity);
        var bird2 = CreateBird(-spreadAngle, baseVelocity);

        Physics2D.IgnoreCollision(bird1.GetComponent<Collider2D>(), bird2.GetComponent<Collider2D>(), true);

        StartCoroutine(ResetCollider(bird1, bird2));
    }

    private BirdController CreateBird(float angle, Vector2 baseVelocity)
    {
        var bird = BirdPoolingSystem.Instance.GetBirdPool(birdType);
        bird.transform.position = transform.position;
        bird.gameObject.SetActive(true);
        bird.skillActive = true;
        bird.launched = true;
        bird.rb2D.bodyType = RigidbodyType2D.Dynamic;
        bird.rb2D.simulated = true;
        Vector2 direction = Quaternion.Euler(0, 0, angle) * baseVelocity.normalized;
        bird.rb2D.AddForce(direction * baseVelocity.magnitude * splitForce, ForceMode2D.Impulse);
        Physics2D.IgnoreCollision(bird.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);

        return bird;
    }

    private IEnumerator ResetCollider(BirdController bird1, BirdController bird2)
    {
        yield return new WaitForSeconds(1.5f);

        if (bird1 != null && bird1.gameObject.activeSelf && gameObject.activeSelf)
        {
            Physics2D.IgnoreCollision(bird1.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
        }

        if (bird2 != null && bird2.gameObject.activeSelf && gameObject.activeSelf)
        {
            Physics2D.IgnoreCollision(bird2.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
        }

        if (bird1 != null && bird2 != null && bird1.gameObject.activeSelf && bird2.gameObject.activeSelf)
        {
            Physics2D.IgnoreCollision(bird1.GetComponent<Collider2D>(), bird2.GetComponent<Collider2D>(), false);
        }
    }
}