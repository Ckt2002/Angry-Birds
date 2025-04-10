using UnityEngine;

[System.Serializable]
public class ParticleFactoryWrapper
{
    [SerializeField] private MonoBehaviour factoryObject;

    public IParticleFactory Factory
    {
        get
        {
            if (factoryObject is IParticleFactory factory)
                return factory;

            Debug.LogError($"Object {factoryObject.name} doesn't implement IParticleFactory");
            return null;
        }
    }
}