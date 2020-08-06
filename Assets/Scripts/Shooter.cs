using System;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	[Header("Projectile")]
	[SerializeField] GameObject prefab;
	[SerializeField] float speed = 1f;
	[SerializeField] float damage = 50f;

	private AttackerSpawner laneAttackerSpawner;

	private void Start()
	{
		SetLaneAttackerSpawner();
	}

	private void Update()
	{
		if (AttackerInLane())
		{
			Debug.Log("Shoot");
		}
		else
		{
			Debug.Log("Wait");
		}
	}

	public void Fire()
	{
		var gunObject = transform.Find("Body").Find("Gun");
		GameObject projectile = Instantiate(prefab, gunObject.transform.position, Quaternion.identity);
		var projectileScript = projectile.GetComponent<Projectile>();
		projectileScript.SetMovementSpeed(speed);
		projectileScript.SetDamage(damage);
	}

	private void SetLaneAttackerSpawner()
	{
		var attackerSpawners = FindObjectsOfType<AttackerSpawner>();
		foreach (var attackerSpawner in attackerSpawners)
		{
			StoreAttackerSpawnerIfOnCurrentLane(attackerSpawner);
		}
	}

	private void StoreAttackerSpawnerIfOnCurrentLane(AttackerSpawner attackerSpawner)
	{
		bool isSpawnerCloseEnough = (Mathf.Abs(attackerSpawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
		if (isSpawnerCloseEnough)
		{
			laneAttackerSpawner = attackerSpawner;
		}
	}

	private bool AttackerInLane()
	{
		var attackersCount = laneAttackerSpawner.transform.childCount;
		return attackersCount > 0;
	}
}
