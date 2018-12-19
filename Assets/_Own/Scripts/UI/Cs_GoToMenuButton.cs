using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cs_GoToMenuButton : MonoBehaviour
{
	public void M_GoToMenu()
	{
		SceneManager.LoadScene(1);
	}
}
