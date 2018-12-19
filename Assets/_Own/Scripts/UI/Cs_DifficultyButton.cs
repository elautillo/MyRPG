using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cs_DifficultyButton : MonoBehaviour
{
	[SerializeField] int difficultyLevel;
	[SerializeField] Button button;

	void Awake()
	{
		button = GetComponent<Button>();

		if (Ps_DataStore.GetDifficulty() == difficultyLevel)
		{
			button.interactable = false;
		}
		else button.interactable = true;
	}

	public void SetDifficulty()
	{
		Ps_DataStore.SetDifficulty(difficultyLevel);
	}
}
