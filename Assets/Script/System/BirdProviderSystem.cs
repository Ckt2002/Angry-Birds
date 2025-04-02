using System.Collections.Generic;
using UnityEngine;

public class BirdProviderSystem : MonoBehaviour
{
    public static BirdProviderSystem Instance { get; private set; }

    private Queue<BirdController> birdsInQueue;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        birdsInQueue = new Queue<BirdController>();
    }

    public void AddBirdToQueue(BirdController bird)
    {
        birdsInQueue.Enqueue(bird);
    }

    public BirdController GetBirdFromQueue()
    {
        if (birdsInQueue.Count == 0)
            return null;

        var birdToGet = birdsInQueue.Dequeue();
        foreach (var bird in birdsInQueue)
        {
            bird.MoveInLineState();
        }
        return birdToGet;
    }
}