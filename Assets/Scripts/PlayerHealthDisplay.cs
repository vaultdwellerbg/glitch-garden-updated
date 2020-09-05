using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    [SerializeField] int health = 5;

    Text healthText;

    private void Start()
    {
        healthText = GetComponent<Text>();
        UpdateDispay();
    }

    public void TakeDamage(int value)
    {
        if (health >= value)
        {
            health -= value;
            UpdateDispay();
        }

        if (health == 0)
        {
            FindObjectOfType<LevelLoader>().LoadGameOverScreenWithDelay();
        }
    }

    private void UpdateDispay()
    {
        healthText.text = "Food: " + health.ToString();
    }
}
