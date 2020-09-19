using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;

    private MusicPlayer musicPlayer;

    private void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    private void Update()
    {
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogError("Music player is missing");
        }
    }

    public void SaveOptions()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
    }

    public void SetDefaultOptions()
    {
        volumeSlider.value = defaultVolume;
    }
}
