using UnityEngine;

public class Fox : MonoBehaviour
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

		if (collidedWith.name.StartsWith("Gravestone"))
		{
			GetComponent<Animator>().SetTrigger("jumpTrigger");
		}
		else if (attacker)
		{
			attacker.Attack(collidedWith);
		}
		else
		{
			Debug.LogError("Missing Attacker script!");
		}
	}
}
