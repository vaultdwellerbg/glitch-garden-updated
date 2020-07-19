using UnityEngine;

public class Projectile : MonoBehaviour
{
	private float movementSpeed = 1f;

	private void Update()
	{
		transform.Translate(Vector2.right * Time.deltaTime * movementSpeed);
	}

	public void SetMovementSpeed(float value)
	{
		movementSpeed = value;
	}
}
