using System.Collections.Generic;
using UnityEngine;

public abstract class ParticleFactory : MonoBehaviour, IParticleFactory
{
    [SerializeField] protected int spawnNumber = 1;
    [SerializeField] protected Transform parent;
    [SerializeField] protected GameObject[] particlePrefabs;

    public virtual List<ParticleController[]> CreateParticle()
    {
        var lst = new List<ParticleController[]>();

        foreach (var particle in particlePrefabs)
        {
            var particles = new ParticleController[spawnNumber];
            for (int i = 0; i < spawnNumber; i++)
            {
                particles[i] = Instantiate(particle, parent).GetComponent<ParticleController>();
                particles[i].gameObject.SetActive(false);
            }
            lst.Add(particles);
        }

        return lst;
    }
}