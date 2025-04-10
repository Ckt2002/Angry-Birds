using UnityEngine;

public class NormalBirdFactory : MonoBehaviour, IBirdFactory
{
    [SerializeField] private int birdNumber = 1;
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject normalBirdPrefab;

    public BirdController[] CreateBird()
    {
        if (normalBirdPrefab == null)
            return null;

        var birdArr = new BirdController[birdNumber];
        for (int i = 0; i < birdNumber; i++)
        {
            birdArr[i] = Instantiate(normalBirdPrefab, parent).GetComponent<BirdController>();
            birdArr[i].gameObject.SetActive(false);
        }

        return birdArr;
    }
}