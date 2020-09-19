﻿using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	AudioSource audioSource;

	private void Start()
	{
		DontDestroyOnLoad(this);
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsController.GetMasterVolume();
	}

	public void SetVolume(float volume)
	{
		audioSource.volume = volume;
	}
}
