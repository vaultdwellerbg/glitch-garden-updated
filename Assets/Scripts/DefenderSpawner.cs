using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
	[SerializeField] GameObject defenderPrefab;

	private void OnMouseDown()
	{
		var mousePos = GetSquareClicked();
		SpawnDefender(mousePos);
	}

	private Vector2 GetSquareClicked()
	{
		Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);

		return worldPos;
	}

	private void SpawnDefender(Vector2 position)
	{
		Instantiate(defenderPrefab, position, Quaternion.identity);
	}
}
