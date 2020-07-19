using UnityEngine;

public class Shooter : MonoBehaviour
{
	[SerializeField] GameObject projectilePrefab;

	public void Fire()
	{
		var gunObject = transform.Find("Gun");
		Instantiate(projectilePrefab, gunObject.transform.position, Quaternion.identity);
	}
}
