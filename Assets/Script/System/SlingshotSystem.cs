using System;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotSystem : MonoBehaviour
{
    public static SlingshotSystem Instance { get; private set; }

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

    public int QueueCount => birdsInQueue.Count;

    public void GetBirdFromQueue()
    {
        birdsInQueue.Dequeue();
    }
}