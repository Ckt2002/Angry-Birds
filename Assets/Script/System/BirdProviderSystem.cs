using System.Collections.Generic;
using UnityEngine;

public class BirdProviderSystem : MonoBehaviour
{
    public static BirdProviderSystem Instance { get; private set; }

    private Queue<BirdController> birdsInQueue;
    private BirdController[] birds;
    private int index = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    #region BirdQueue
    public void InitializationBirdQueue()
    {
        birdsInQueue = new();
    }

    public void AddBirdToQueue(BirdController bird)
    {
        if (bird != null && birdsInQueue != null)
            birdsInQueue.Enqueue(bird);
    }

    public BirdController GetBirdFromQueue()
    {
        if (birdsInQueue.Count == 0)
            return null;

        foreach (var bird in birdsInQueue)
            bird.MoveInLineState();

        return birdsInQueue.Dequeue();
    }

    public void ResetBirdQueue()
    {
        while (birdsInQueue.Count > 0)
        {
            var bird = birdsInQueue.Dequeue();
            bird.gameObject.SetActive(false);
        }
    }
    #endregion

    #region BirdList

    public void InitializationBirdList(int size)
    {
        birds = new BirdController[size];
        ResetIndex();
    }

    public void ResetIndex()
    {
        index = 0;
    }

    public void AddBirdToList(BirdController bird)
    {
        if (index < birds.Length)
        {
            birds[index] = bird;
            index++;
        }
    }

    public BirdController GetBirdFromList()
    {
        if (index < birds.Length && birds.Length > 0)
        {
            index++;
            return birds[index];
        }

        return null;
    }

    public void ResetBirdInList()
    {
        foreach (var bird in birds)
        {
            if (bird.gameObject.activeInHierarchy)
                bird.gameObject.SetActive(false);
        }
        birds = null;
    }
    #endregion
}
