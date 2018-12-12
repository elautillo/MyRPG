using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Fan : MonoBehaviour
{
	[SerializeField] int f_rotationSpeed = 10;
	
	
	void Update()
	{
		transform.Rotate(0, 0, Time.deltaTime * f_rotationSpeed);
	}
}