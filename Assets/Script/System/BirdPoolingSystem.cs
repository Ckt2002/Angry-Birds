using System;
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
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        InitializeBirds();
    }

    private void InitializeBirds()
    {
        birdDictionary = new Dictionary<EBirdType, BirdController[]>();
        foreach (var birdType in birdTypeToSpawn)
        {
            CreateBird(birdType);
        }
    }

    private void CreateBird(EBirdType birdType)
    {
        switch (birdType)
        {
            case EBirdType.Normal:
                var normalBirds = birdFactories[0].Factory.CreateBird();
                UpdateDictionary(EBirdType.Normal, normalBirds);
                break;

            case EBirdType.Triple:
                var tripleBirds = birdFactories[1].Factory.CreateBird();
                UpdateDictionary(EBirdType.Normal, tripleBirds);
                break;

            case EBirdType.Bomb:
                var bombBirds = birdFactories[2].Factory.CreateBird();
                UpdateDictionary(EBirdType.Normal, bombBirds);
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
}