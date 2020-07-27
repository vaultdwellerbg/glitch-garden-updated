using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
	Defender defenderPrefab;

	private void OnMouseDown()
	{
		var mousePos = GetSquareClicked();
		SpawnDefender(mousePos);
	}

	public void SetSelectedDefender(Defender value)
	{
		defenderPrefab = value;
	}

	private Vector2 GetSquareClicked()
	{
		Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);

		return SnapToGrid(worldPos);
	}

	private Vector2 SnapToGrid(Vector2 rawPos)
	{
		float gridX = Mathf.RoundToInt(rawPos.x);
		float gridY = Mathf.RoundToInt(rawPos.y);

		return new Vector2(gridX, gridY);
	}

	private void SpawnDefender(Vector2 position)
	{
		Instantiate(defenderPrefab, position, Quaternion.identity);
	}
}
