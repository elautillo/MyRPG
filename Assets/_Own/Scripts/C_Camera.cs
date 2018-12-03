using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Camera : MonoBehaviour
{
	private Camera myCam;

	void Awake ()
	{
		myCam = GetComponent<Camera>();
	}

	void Update()
	{
		myCam.ScreenPointToRay(Input.mousePosition);
	}
}
