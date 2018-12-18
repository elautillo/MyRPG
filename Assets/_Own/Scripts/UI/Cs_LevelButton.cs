using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cs_LevelButton : MonoBehaviour
{
	Button button;
	[SerializeField] int f_sceneNumber;


	void Awake()
	{
		button = GetComponent<Button>();
		button.interactable = false;
	}


	void Start()
	{
		if (Ps_DataStore.GetSavedScene() == f_sceneNumber)
		{
			button.interactable = true;
		}
	}


	public void M_LoadLevel()
	{
		SceneManager.LoadScene(f_sceneNumber);	
	}
}
