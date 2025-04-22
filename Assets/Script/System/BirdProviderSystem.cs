using System.Collections.Generic;
using UnityEngine;

public class BirdProviderSystem : MonoBehaviour
{
    public static BirdProviderSystem Instance { get; private set; }

    private Queue<BirdController> birdsInQueue;
    private int currentIndex = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void InitializationBirdQueue()
    {
        birdsInQueue = new();
    }

    public void AddBirdToQueue(BirdController bird)
    {
        if (bird != null && birdsInQueue != null)
        {
            birdsInQueue.Enqueue(bird);
        }
    }

    public void ResetIndex()
    {
        currentIndex = 0;
    }

    public BirdController GetBirdFromQueue()
    {
        if (birdsInQueue.Count == 0)
            return null;

        foreach (var bird in birdsInQueue)
            bird.MoveInLineState();

        return birdsInQueue.Dequeue();
    }
}
