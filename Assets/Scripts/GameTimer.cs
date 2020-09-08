using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("The level timer in seconds.")]
    [SerializeField] float levelTime = 10f;

	private bool levelFinished = false;

	private void Update()
	{
		if (levelFinished) return;

		bool timerFinished = Time.timeSinceLevelLoad >= levelTime;
		if (timerFinished)
		{
			FindObjectOfType<LevelController>().LevelTimerFinished();
			levelFinished = true;
			return;
		}

		GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
	}
}
