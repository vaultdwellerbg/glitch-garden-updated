using UnityEngine;

public class Shooter : MonoBehaviour
{
	[Header("Projectile")]
	[SerializeField] GameObject prefab;
	[SerializeField] float speed = 1f;
	[SerializeField] float damage = 50f;

	public void Fire()
	{
		var gunObject = transform.Find("Body").Find("Gun");
		GameObject projectile = Instantiate(prefab, gunObject.transform.position, Quaternion.identity);
		var projectileScript = projectile.GetComponent<Projectile>();
		projectileScript.SetMovementSpeed(speed);
		projectileScript.SetDamage(damage);
	}
}
