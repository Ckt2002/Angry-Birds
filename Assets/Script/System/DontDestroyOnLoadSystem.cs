using UnityEngine;

public class DontDestroyOnLoadSystem : MonoBehaviour
{
    public static DontDestroyOnLoadSystem Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
}
