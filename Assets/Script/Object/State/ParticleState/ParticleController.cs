using System.Collections;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private new ParticleSystem particleSystem;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    public void RunParticle(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
        particleSystem.Play();
        StartCoroutine(ParticleProgress());
    }

    private IEnumerator ParticleProgress()
    {
        while (particleSystem.IsAlive())
            yield return null;
        gameObject.SetActive(false);
    }
}