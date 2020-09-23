using UnityEngine;

public class PlayerBase : MonoBehaviour
{
	private PlayerHealthDisplay health;

	private void Start()
	{
		health = FindObjectOfType<PlayerHealthDisplay>();
	}

	private void OnTriggerEnter2D(Collider2D collidedWith)
	{
		if (health)
		{
			health.TakeDamage(1);
		}
		else 
		{
			Debug.LogError("PlayerHealthDisplay missing!");
		}
		Destroy(collidedWith.gameObject);
	}
}
