using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Fan : MonoBehaviour
{
	[SerializeField] int m_speed;
	

	void Update()
	{
		transform.Rotate(0, 0, Time.deltaTime * m_speed);
	}
}