using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSystem : MonoBehaviour
{
    public static SceneSystem Instance;
    [SerializeField] private Animator transitionAnimator;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    #region Load scene
    public void LoadScene(int sceneInd)
    {
        StartCoroutine(Scene(sceneInd));
    }

    IEnumerator Scene(int sceneInd)
    {
        transitionAnimator.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync(sceneInd);
        transitionAnimator.SetTrigger("Start");
    }
    #endregion

    #region Load level
    public void LoadLevel()
    {
        StartCoroutine(Level());
    }

    IEnumerator Level()
    {
        transitionAnimator.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        transitionAnimator.SetTrigger("Start");
    }
    #endregion
}
