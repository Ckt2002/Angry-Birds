using System.Collections;
using UnityEngine;

public class TripleBird : BirdController
{
    [SerializeField] private float spreadAngle = 30f;
    [SerializeField] private float splitForce = 2f;
    public bool isSkillBird { get; set; } = false;

    protected override void SpecialSkill()
    {
        var baseVelocity = rb2D.linearVelocity;
        var particle = ParticlePoolingSystem.Instance.GetParticle(name);
        particle?.RunParticle(transform.position);
        soundManager.PlaySFXAudioOneShot((int)ESFXAudioClip.BirdSkill);
        anim?.RunSpecialSkill();

        TripleBird bird1 = CreateBird(spreadAngle, baseVelocity);
        TripleBird bird2 = CreateBird(-spreadAngle, baseVelocity);
        bird1.isSkillBird = bird2.isSkillBird = true;

        Physics2D.IgnoreCollision(bird1.GetComponent<Collider2D>(), bird2.GetComponent<Collider2D>(), true);

        StartCoroutine(ResetCollider(bird1, bird2));
    }

    private TripleBird CreateBird(float angle, Vector2 baseVelocity)
    {
        var bird = BirdPoolingSystem.Instance.GetBirdPool(birdType) as TripleBird;
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

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (launched && !other.gameObject.CompareTag(nameof(ETags.Player)))
        {
            if (!isSkillBird)
                stateMachine.ChangeState(new BirdColliedState(this, anim, name, soundManager));
            else
                stateMachine.ChangeState(new TripleSkillColliedState(this, anim, name, soundManager));
        }
    }

    protected override void Reset()
    {
        base.Reset();
        isSkillBird = false;
    }
}