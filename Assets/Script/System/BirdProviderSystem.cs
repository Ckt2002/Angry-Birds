using UnityEngine;

public class BirdProviderSystem : MonoBehaviour
{
    public static BirdProviderSystem Instance { get; private set; }

    //private Queue<BirdController> birdsInQueue;
    public BirdController[] birds { get; private set; }

    private int index = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    #region BirdQueue
    //public void InitializationBirdQueue()
    //{
    //    birdsInQueue = new();
    //}

    //public void AddBirdToQueue(BirdController bird)
    //{
    //    if (bird != null && birdsInQueue != null)
    //        birdsInQueue.Enqueue(bird);
    //}

    //public BirdController GetBirdFromQueue()
    //{
    //    if (birdsInQueue.Count == 0)
    //        return null;

    //    foreach (var bird in birdsInQueue)
    //        bird.MoveInLineState();

    //    return birdsInQueue.Dequeue();
    //}

    //public void ResetBirdQueue()
    //{
    //    while (birdsInQueue.Count > 0)
    //    {
    //        var bird = birdsInQueue.Dequeue();
    //        bird.gameObject.SetActive(false);
    //    }
    //}
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
        if (birds == null)
        {
            Debug.Log("list is null");
            return null;
        }

        if (index < birds.Length && birds.Length > 0)
        {
            var bird = birds[index];
            index++;
            return bird;
        }

        return null;
    }

    public void ResetBirdInList()
    {
        if (birds != null)
        {
            foreach (var bird in birds)
                if (bird.gameObject.activeInHierarchy)
                    bird.gameObject.SetActive(false);

            birds = null;
        }
        index = 0;
    }
    #endregion
}
