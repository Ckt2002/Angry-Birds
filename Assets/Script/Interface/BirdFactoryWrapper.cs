using UnityEngine;

[System.Serializable]
public class BirdFactoryWrapper
{
    [SerializeField] private MonoBehaviour factoryObject;

    public IBirdFactory Factory
    {
        get
        {
            if (factoryObject is IBirdFactory factory)
                return factory;

            Debug.LogError($"Object {factoryObject.name} doesn't implement IBirdFactory");
            return null;
        }
    }
}