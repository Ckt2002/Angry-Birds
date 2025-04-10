using UnityEngine;

public class TripleBirdFactory : MonoBehaviour, IBirdFactory
{
    [SerializeField] private int birdNumber = 1;
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject tripleBirdPrefab;

    public BirdController[] CreateBird()
    {
        if (tripleBirdPrefab == null)
            return null;

        var birdArr = new BirdController[birdNumber];
        for (int i = 0; i < birdNumber; i++)
        {
            birdArr[i] = Instantiate(tripleBirdPrefab, parent).GetComponent<BirdController>();
            birdArr[i].gameObject.SetActive(false);
        }

        return birdArr;
    }
}