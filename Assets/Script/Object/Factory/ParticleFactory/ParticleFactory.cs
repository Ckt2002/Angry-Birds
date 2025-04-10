using UnityEngine;

public abstract class ParticleFactory : MonoBehaviour, IParticleFactory
{
    [SerializeField] protected int spawnNumber = 1;
    [SerializeField] protected Transform parent;
    [SerializeField] protected GameObject[] particlePrefabs;

    public virtual ParticleController[] CreateParticle()
    {
        var particles = new ParticleController[spawnNumber];

        foreach (var particle in particlePrefabs)
        {
            for (int i = 0; i < spawnNumber; i++)
            {
                particles[i] = Instantiate(particle, parent).GetComponent<ParticleController>();
                particles[i].gameObject.SetActive(false);
            }
        }

        return particles;
    }
}