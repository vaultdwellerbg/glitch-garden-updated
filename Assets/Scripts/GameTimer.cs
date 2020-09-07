using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("The level timer in seconds.")]
    [SerializeField] float levelTime = 10f;

	private void Update()
	{
		bool timerFinished = Time.timeSinceLevelLoad >= levelTime;
		if (timerFinished)
		{
			Debug.Log("Level timer finished.");
			return;
		}

		GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
	}
}
