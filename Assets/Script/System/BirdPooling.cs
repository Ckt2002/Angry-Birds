using System.Collections.Generic;
using Script.Enum;
using UnityEngine;

public class BirdPooling : MonoBehaviour
{
    [SerializeField] private EBirdType[] birdTypeToSpawn;

    //! Fix interface here
    [SerializeField] private IBirdFactory[] birdFactories;
    public Dictionary<EBirdType, BirdController[]> birdDictionary;

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
                var normalBirds = birdFactories[0].CreateBird();
                UpdateDictionary(EBirdType.Normal, normalBirds);
                break;

            case EBirdType.Triple:
                var tripleBirds = birdFactories[1].CreateBird();
                UpdateDictionary(EBirdType.Normal, tripleBirds);
                break;

            case EBirdType.Bomb:
                var bombBirds = birdFactories[2].CreateBird();
                UpdateDictionary(EBirdType.Normal, bombBirds);
                break;

            default:
                Debug.LogError("Undefined bird type enum");
                break;
        }
    }

    private void UpdateDictionary(EBirdType birdType, BirdController[] birdArr)
    {
        birdDictionary.Add(birdType, birdArr);
    }
}