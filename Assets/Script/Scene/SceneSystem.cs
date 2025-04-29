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
    public void NextLevel()
    {
        StartCoroutine(Next());
    }

    IEnumerator Next()
    {
        transitionAnimator.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        yield return asyncLoad;
        BirdProviderSystem.Instance.ResetBirdInList();
        LevelSystem.Instance.NextLevel();
        transitionAnimator.SetTrigger("Start");
    }
    #endregion

    #region Restart level
    public void RestartLevel()
    {
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        transitionAnimator.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        yield return asyncLoad;
        BirdProviderSystem.Instance.ResetBirdInList();
        LevelSystem.Instance.LoadLevel();
        transitionAnimator.SetTrigger("Start");
    }
    #endregion

    #region Load level
    public void LoadLevel(int level)
    {
        StartCoroutine(Load(level));
    }

    IEnumerator Load(int level)
    {
        transitionAnimator.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        yield return asyncLoad;
        BirdProviderSystem.Instance.ResetBirdInList();
        LevelSystem.Instance.SetLevel(level);
        transitionAnimator.SetTrigger("Start");
    }
    #endregion
}
