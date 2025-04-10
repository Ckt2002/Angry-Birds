using System.Collections.Generic;
using UnityEngine;

public class ParticlePoolingSystem : MonoBehaviour
{
    public static ParticlePoolingSystem Instance { get; private set; }
    [SerializeField] private ParticleFactoryWrapper[] particleFactories;
    public Dictionary<string, ParticleController[]> particleDictionary { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        InitializeBirds();
    }

    private void InitializeBirds()
    {
        particleDictionary = new Dictionary<string, ParticleController[]>();

        foreach (var factory in particleFactories)
        {
            var spawned = factory.Factory.CreateParticle();
            var key = spawned[0].gameObject.name.Replace("(Clone)", "");
            particleDictionary.TryAdd(key, spawned);
        }
    }

    public ParticleController GetParticle(string particleName)
    {
        if (particleDictionary.ContainsKey(particleName))
            foreach (var item in particleDictionary[particleName])
                if (!item.gameObject.activeInHierarchy)
                    return item;

        Debug.LogWarning("Name doesn't exist in particle dictionary");
        return null;
    }
}