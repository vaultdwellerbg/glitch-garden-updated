using System;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
	[SerializeField] Defender defenderPrefab;

	private void Start()
	{
		DisplayCost();
	}

	private void OnMouseDown()
	{
		SetActive();
		FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
	}

	private void DisplayCost()
	{
		Text costLabel = GetComponentInChildren<Text>();
		if (costLabel)
		{
			costLabel.text = defenderPrefab.GetCost().ToString();
		}
		else 
		{
			Debug.LogError(name + " is missing cost text object!");
		}
	}

	private void SetActive()
	{
		var defenderButtons = FindObjectsOfType<DefenderButton>();
		foreach (DefenderButton button in defenderButtons)
		{
			button.GetComponent<SpriteRenderer>().color = new Color32(51, 51, 51, 255);
		}
		GetComponent<SpriteRenderer>().color = Color.white;
	}
}
