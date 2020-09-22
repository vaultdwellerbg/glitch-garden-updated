using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
	private float levelTime;
	private bool levelFinished = false;

	private void Start()
	{
		levelTime = FindObjectOfType<DifficultyController>().GetLevelTime();
	}

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
