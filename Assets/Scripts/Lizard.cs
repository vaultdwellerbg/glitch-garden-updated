using UnityEngine;

public class Lizard : MonoBehaviour
{
	Attacker attacker;

	private void Start()
	{
		attacker = GetComponent<Attacker>();
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		GameObject collidedWith = collider.gameObject;

		if (!collidedWith.GetComponent<Defender>()) return;

		if (attacker)
		{
			attacker.Attack(collidedWith);
		}
		else
		{
			Debug.LogError("Missing Attacker script!");
		}
	}
}
