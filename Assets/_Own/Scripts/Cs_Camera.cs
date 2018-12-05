using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Camera : MonoBehaviour
{
	Camera f_cam;


	void Awake()
	{
		f_cam = GetComponent<Camera>();
	}


	void Update()
	{
		f_cam.ScreenPointToRay(Input.mousePosition);
	}
}
