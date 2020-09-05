using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float spashScreenDuration = 3f;
    [SerializeField] float gameOverTransitionDuration = 3f;

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
        SceneManager.LoadScene("StartScreen");
    }

    public void LoadGameOverScreenWithDelay()
    {
        StartCoroutine("LoadGameOverScreen");
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
}
