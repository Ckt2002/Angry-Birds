using System.Collections;
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
        StartCoroutine(InitializeBirds());
    }

    private IEnumerator InitializeBirds()
    {
        particleDictionary = new Dictionary<string, ParticleController[]>();

        foreach (var factory in particleFactories)
        {
            var spawned = factory.Factory.CreateParticle();
            foreach (var item in spawned)
            {
                var key = item[0].gameObject.name.Replace("(Clone)", "");
                particleDictionary.TryAdd(key, item);
                yield return new WaitForSeconds(0.0002f);
            }
            yield return new WaitForSeconds(0.002f);
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