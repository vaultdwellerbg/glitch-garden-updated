using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float spashScreenDuration = 3f;
    [SerializeField] float gameOverTransitionDuration = 3f;
    [SerializeField] float nextLevelTransitionDuration = 3f;

    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine("LoadStartScreen");
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");
    }

    public void ReloadCurrentScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadGameOverScreenWithDelay()
    {
        StartCoroutine("LoadGameOverScreen");
    }

    public void LevelCompleted()
    {
        StartCoroutine("LoadNextSceneWithDelay");
    }

    private IEnumerator LoadStartScreen()
    {
        yield return new WaitForSeconds(spashScreenDuration);

        LoadNextScene();
    }

    private IEnumerator LoadGameOverScreen()
    {
        yield return new WaitForSeconds(gameOverTransitionDuration);

        SceneManager.LoadScene("GameOverScreen");
    }

    private IEnumerator LoadNextSceneWithDelay()
    {
        yield return new WaitForSeconds(nextLevelTransitionDuration);

        LoadNextScene();
    }
}
