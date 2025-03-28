using System.Collections.Generic;
using UnityEngine;

public class BirdSystem : MonoBehaviour
{
    public static BirdSystem Instance { get; private set; }

    private GameObject[] birdsArr;
    private readonly Queue<GameObject> birdsQueue = new();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        birdsArr = GameObject.FindGameObjectsWithTag(nameof(Tags.Player));
        AddBirdsToQueue();
    }

    private void AddBirdsToQueue()
    {
        foreach (var bird in birdsArr) birdsQueue.Enqueue(bird);
    }

    public GameObject GetNextBird()
    {
        if (birdsQueue.Count <= 0) return null;

        return birdsQueue.Dequeue();
    }
}