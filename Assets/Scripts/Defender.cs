using UnityEngine;

public class Defender : MonoBehaviour
{
	[SerializeField] int cost = 100;

	public void AddGold(int value)
	{
		var resourceDisplay = FindObjectOfType<ResourceDisplay>();
		if (resourceDisplay)
		{
			resourceDisplay.AddGold(value);
		}
		else
		{
			Debug.LogError("No ResourceDisplay object found!");
		}
	}

	public int GetCost()
	{
		return cost;
	}
}
