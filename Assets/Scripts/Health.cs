using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFXPrefab;

    public void DealDamage(float value)
    {
        health -= value;
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFXPrefab) return;

        GameObject deathVFX = Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
        Destroy(deathVFX, 1f);
    }
}
