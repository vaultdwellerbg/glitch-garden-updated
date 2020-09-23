using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
	const string DEFENDER_PARENT_NAME = "Defenders";

	private Defender defenderPrefab;
	private ResourceDisplay resourseDisplay;
	private GameObject defenderParent;

	private void Start()
	{
		resourseDisplay = FindObjectOfType<ResourceDisplay>();
		CreateDefenderParent();
	}

	private void CreateDefenderParent()
	{
		defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
		if (!defenderParent)
		{
			defenderParent = new GameObject(DEFENDER_PARENT_NAME);
		}
	}

	private void OnMouseDown()
	{
		var mousePos = GetSquareClicked();
		AttemptToPlaceSelectedDefender(mousePos);
	}

	public void SetSelectedDefender(Defender value)
	{
		defenderPrefab = value;
	}

	private void AttemptToPlaceSelectedDefender(Vector2 pos)
	{
		var defenderCost = defenderPrefab.GetCost();
		if (resourseDisplay.GetGold() >= defenderCost)
		{
			SpawnDefender(pos);
			resourseDisplay.SpendGold(defenderCost);
		}
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
		Defender newDefender = Instantiate(defenderPrefab, position, Quaternion.identity) as Defender;
		newDefender.transform.parent = defenderParent.transform;
	}
}
