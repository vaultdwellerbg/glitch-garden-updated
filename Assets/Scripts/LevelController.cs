using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject levelCompleteLable;

    private int numberOfAttackers = 0;
    private bool levelTimerFinished = false;

	private void Start()
	{
        levelCompleteLable.SetActive(false);
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

    private void HandleWinCondition()
    {
        GetComponent<AudioSource>().Play();
        levelCompleteLable.SetActive(true);
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
}
