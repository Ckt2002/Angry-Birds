using System.Collections;
using UnityEngine;

namespace Script.Object.BirdType
{
    public class BombBird : BirdController
    {
        [SerializeField] private float explodeRange;
        [SerializeField] private float explosionForce;

        protected override void SpecialSkill()
        {
            BirdStopMoving();

            StartCoroutine(HandleSpecialSkill());
        }

        IEnumerator HandleSpecialSkill()
        {
            soundManager.PlaySFXAudioOneShot((int)ESFXAudioClip.BirdSkill);
            var particle = ParticlePoolingSystem.Instance.GetParticle(name);
            particle?.RunParticle(transform.position);
            soundManager.PlaySFXAudioOneShot((int)ESFXAudioClip.BirdExplode);

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explodeRange);

            foreach (Collider2D hit in colliders)
            {
                if (hit.gameObject == gameObject || hit.CompareTag(nameof(ETags.Player)))
                    continue;

                var hitDistance = Vector2.Distance(transform.position, hit.transform.position);

                EnemyController enemy = hit.GetComponent<EnemyController>();
                Vector2 direction = (hit.transform.position - transform.position).normalized;

                if (enemy != null)
                {
                    enemy.EnemyExplosionState(hitDistance - explodeRange, explosionForce, direction);
                    continue;
                }

                ObstacleController obstacle = hit.GetComponent<ObstacleController>();
                if (obstacle != null)
                    obstacle.ObstacleExplosionState(hitDistance - explodeRange, explosionForce, direction);
            }

            yield return null;

            gameObject.SetActive(false);
        }

        private void BirdStopMoving()
        {
            rb2D.linearVelocity = Vector3.zero;
            rb2D.angularVelocity = 0f;
            rb2D.bodyType = RigidbodyType2D.Kinematic;
            rb2D.simulated = false;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, explodeRange);
        }
    }
}