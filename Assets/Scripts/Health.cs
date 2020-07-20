using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void DealDamage(float value)
    {
        health -= value;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
