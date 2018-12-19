using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cs_GoToMenuButton : MonoBehaviour
{
	public void M_GoToMenu()
	{
		if (SceneManager.GetActiveScene().buildIndex == 3)
		{
			
		}
		SceneManager.LoadScene(1);
	}
}
