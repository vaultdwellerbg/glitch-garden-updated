using System;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int numberOfAttackers = 0;
    private bool levelTimerFinished = false;

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerDestroyed()
    {
        numberOfAttackers--;

        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            Debug.Log("End level");
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopAttackerSpawners();
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
