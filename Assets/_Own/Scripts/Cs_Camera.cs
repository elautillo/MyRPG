using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Camera : MonoBehaviour
{
	Camera f_Cam;

	void Awake()
	{
		f_Cam = GetComponent<Camera>();
	}

	void Update()
	{
		f_Cam.ScreenPointToRay(Input.mousePosition);
	}
}
