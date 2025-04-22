using System.Collections.Generic;
using Script.Enum;
using UnityEngine;

public class BirdPoolingSystem : MonoBehaviour
{
    public static BirdPoolingSystem Instance { get; private set; }
    [SerializeField] private EBirdType[] birdTypeToSpawn;
    [SerializeField] private BirdFactoryWrapper[] birdFactories;
    public Dictionary<EBirdType, BirdController[]> birdDictionary { get; private set; }

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
        birdDictionary = new Dictionary<EBirdType, BirdController[]>();
        foreach (var birdType in birdTypeToSpawn)
            CreateBird(birdType);
    }

    private void CreateBird(EBirdType birdType)
    {
        switch (birdType)
        {
            case EBirdType.Normal:
                var normalBirds = birdFactories[(int)birdType].Factory.CreateBird();
                UpdateDictionary(EBirdType.Normal, normalBirds);
                break;

            case EBirdType.Flash:
                var flashBirds = birdFactories[(int)birdType].Factory.CreateBird();
                UpdateDictionary(EBirdType.Flash, flashBirds);
                break;

            case EBirdType.Triple:
                var tripleBirds = birdFactories[(int)birdType].Factory.CreateBird();
                UpdateDictionary(EBirdType.Triple, tripleBirds);
                break;

            case EBirdType.Bomb:
                var bombBirds = birdFactories[(int)birdType].Factory.CreateBird();
                UpdateDictionary(EBirdType.Bomb, bombBirds);
                break;

            default:
                Debug.LogError("Undefined bird type enum");
                break;
        }
    }

    private void UpdateDictionary(EBirdType birdType, BirdController[] birdArr)
    {
        birdDictionary.TryAdd(birdType, birdArr);
    }

    public BirdController GetBirdPool(EBirdType birdType)
    {
        if (!birdDictionary.TryGetValue(birdType, out var value))
        {
            Debug.LogWarning($"Bird type: {birdType} not found in dictionary");
            return null;
        }

        foreach (var bird in value)
            if (!bird.gameObject.activeInHierarchy)
                return bird;

        Debug.LogWarning($"{birdType} bird out of number");
        return null;
    }
}