using UnityEngine;

public class FlashBird : BirdController
{
    [SerializeField] private float speedSkill = 5f;

    protected override void SpecialSkill()
    {
        var direction = rb2D.linearVelocity.normalized;
        var currentSpeed = rb2D.linearVelocity.magnitude;
        rb2D.linearVelocity = speedSkill * direction * currentSpeed;

        // Run particle
        var particle = ParticlePoolingSystem.Instance.GetParticle(name);
        particle?.RunParticle(transform.position);

        soundManager.PlaySFXAudioOneShot((int)ESFXAudioClip.BirdSkill);
    }
}
