using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDisplay : MonoBehaviour
{
	[SerializeField] int gold = 100;

	Text starText;

	private void Start()
	{
		starText = GetComponent<Text>();
		UpdateDispay();
	}

	public void AddGold(int value)
	{
		gold += value;
		UpdateDispay();
	}

	public void SpendGold(int value)
	{
		if (gold >= value)
		{
			gold -= value;
			UpdateDispay();
		}
	}

	public int GetGold()
	{
		return gold;
	}

	private void UpdateDispay()
	{
		starText.text = gold.ToString();
	}
}
