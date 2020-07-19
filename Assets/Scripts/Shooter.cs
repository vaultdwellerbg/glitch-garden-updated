using UnityEngine;

public class Shooter : MonoBehaviour
{
	[SerializeField] GameObject projectilePrefab;
	[SerializeField] float projectileSpeed = 1f;

	public void Fire()
	{
		var gunObject = transform.Find("Gun");
		GameObject projectile = Instantiate(projectilePrefab, gunObject.transform.position, Quaternion.identity);
		projectile.GetComponent<Projectile>().SetMovementSpeed(projectileSpeed);
	}
}
