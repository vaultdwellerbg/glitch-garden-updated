using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject levelCompleteLabel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] float gameOverTransitionDuration = 3f;
    [Header("Audio")]
    [SerializeField] AudioClip winAudio;
    [SerializeField] AudioClip loseAudio;

    private int numberOfAttackers = 0;
    private bool levelTimerFinished = false;
    private AudioSource audioSource;

	private void Start()
	{
        audioSource = GetComponent<AudioSource>();

        levelCompleteLabel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

	public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerDestroyed()
    {
        numberOfAttackers--;

        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            HandleWinCondition();
        }
    }

	public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopAttackerSpawners();
    }

    public void ShowGameOverPanelWithDelay()
    {
        audioSource.clip = loseAudio;
        audioSource.Play();
        StartCoroutine("ShowGameOverPanel");
    }

    private void HandleWinCondition()
    {
        audioSource.clip = winAudio;
        audioSource.Play();
        levelCompleteLabel.SetActive(true);
        FindObjectOfType<LevelLoader>().LevelCompleted();
    }

    private void StopAttackerSpawners()
	{
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
		foreach (var spawner in spawners)
		{
            spawner.StopSpawning();
		}
	}

    private IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSeconds(gameOverTransitionDuration);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
