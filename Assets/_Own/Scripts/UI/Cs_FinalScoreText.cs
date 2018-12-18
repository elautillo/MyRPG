using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cs_FinalScoreText : MonoBehaviour
{
	Text scoreText;
	


	void Awake()
	{
		scoreText = GetComponent<Text>();
	}


	void Start()
	{
		scoreText.text = "Final Score: " + Ps_DataStore.GetSavedScore();
	}
}
