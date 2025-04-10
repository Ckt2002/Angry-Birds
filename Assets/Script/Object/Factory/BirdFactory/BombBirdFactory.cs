using UnityEngine;

public class BombBirdFactory : MonoBehaviour, IBirdFactory
{

    [SerializeField] private int birdNumber = 1;
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject bombBirdPrefab;

    public BirdController[] CreateBird()
    {
        if (bombBirdPrefab == null)
            return null;

        var birdArr = new BirdController[birdNumber];
        for (int i = 0; i < birdNumber; i++)
        {
            birdArr[i] = Instantiate(bombBirdPrefab, parent).GetComponent<BirdController>();
            birdArr[i].gameObject.SetActive(false);
        }

        return birdArr;
    }
}