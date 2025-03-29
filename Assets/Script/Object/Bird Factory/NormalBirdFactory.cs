using UnityEngine;

public class NormalBirdFactory : MonoBehaviour, IBirdFactory
{
    [SerializeField] protected int birdNumber = 1;
    [SerializeField] protected Transform parent;
    [SerializeField] protected GameObject normalBirdPrefab;

    public BirdController[] CreateBird()
    {
        var birdArr = new BirdController[birdNumber];
        for (int i = 1; i <= birdNumber; i++)
        {
            birdArr[i] = Instantiate(normalBirdPrefab, parent).GetComponent<BirdController>();
        }

        return birdArr;
    }
}