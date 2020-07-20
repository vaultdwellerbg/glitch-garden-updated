using UnityEngine;

public class Projectile : MonoBehaviour
{
	private float movementSpeed = 1f;
	private float damage = 50f;

	private void Update()
	{
		transform.Translate(Vector2.right * Time.deltaTime * movementSpeed);
	}

	public void SetMovementSpeed(float value)
	{
		movementSpeed = value;
	}

	public void SetDamage(float value)
	{
		damage = value;
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		var colliderHealth = collider.gameObject.GetComponent<Health>();
		if (colliderHealth != null)
		{
			colliderHealth.DealDamage(damage);
		}
	}
}
