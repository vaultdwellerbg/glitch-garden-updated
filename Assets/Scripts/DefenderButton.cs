using UnityEngine;

public class DefenderButton : MonoBehaviour
{
	private void OnMouseDown()
	{
		var defenderButtons = FindObjectsOfType<DefenderButton>();
		foreach (DefenderButton button in defenderButtons)
		{
			button.GetComponent<SpriteRenderer>().color = new Color32(51, 51, 51, 255);
		}
		GetComponent<SpriteRenderer>().color = Color.white;
	}
}
