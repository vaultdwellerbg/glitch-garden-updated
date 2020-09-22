using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    [SerializeField] [Tooltip("From easy to hard")] int[] health = new int[3] { 8, 5, 3 };
    [SerializeField] [Tooltip("From easy to hard, in seconds")] float[] levelTime = new float[3] { 10f, 15f, 20f };

    private int currentDifficulty;

    private void Start()
    {
        currentDifficulty = PlayerPrefsController.GetDifficulty();
    }

    public int GetHealth()
    {
        return health[currentDifficulty];
    }

    public float GetLevelTime()
    {
        return levelTime[currentDifficulty];
    }
}
