using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cs_ResultText : MonoBehaviour
{
	Text f_text;

	void Awake()
	{
		f_text = GetComponent<Text>();
	}

	void Start()
	{
		if (Ps_DataStore.GetResult() == 0)
		{
			f_text.text	= "You lose";
		}
		else
		{
			f_text.text = "You win";
		}
	}
}
