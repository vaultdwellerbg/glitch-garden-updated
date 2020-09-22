using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    int health;
    Text healthText;

    private void Start()
    {
        health = FindObjectOfType<DifficultyController>().GetHealth();
        healthText = GetComponent<Text>();
        UpdateDispay();
    }

    public void TakeDamage(int value)
    {
        health -= value;

        if (health >= value)
        {
            UpdateDispay();
        }

        if (health == 0)
        {
            FindObjectOfType<LevelController>().ShowGameOverPanelWithDelay();
        }
    }

    private void UpdateDispay()
    {
        healthText.text = "Food: " + health.ToString();
    }
}
