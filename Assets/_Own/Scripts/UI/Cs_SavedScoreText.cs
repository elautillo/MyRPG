using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cs_SavedScoreText : MonoBehaviour
{
	Text scoreText;


	void Awake()
	{
		scoreText = GetComponent<Text>();
	}


	void Start()
	{
		scoreText.text = "Max Score: " + Ps_DataStore.GetSavedMaxScore();
	}
}
