using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;
    [SerializeField] Slider difficultySlider;
    [SerializeField] int defaultDifficulty = 1;

    private MusicPlayer musicPlayer;

    private void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
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

        Debug.Log(PlayerPrefsController.GetDifficulty());
    }

    public void SaveOptions()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty((int)difficultySlider.value);
    }

    public void SetDefaultOptions()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
