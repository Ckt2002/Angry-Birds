using UnityEngine;
using UnityEngine.Serialization;

public class TripleBirdFactory : MonoBehaviour, IBirdFactory
{
    [SerializeField] protected int birdNumber = 1;
    [SerializeField] protected Transform parent;
    [SerializeField] protected GameObject tripleBirdPrefab;

    public BirdController[] CreateBird()
    {
        var birdArr = new BirdController[birdNumber];
        for (int i = 1; i <= birdNumber; i++)
        {
            birdArr[i] = Instantiate(tripleBirdPrefab, parent).GetComponent<BirdController>();
        }

        return birdArr;
    }
}