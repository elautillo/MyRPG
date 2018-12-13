using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Cs_Camera : MonoBehaviour
{
	[SerializeField] CinemachineFreeLook f_cmFreeLook;
	
	void Update()
	{
		if (Input.GetKey(Ps_Input.GetCameraShiftKey()))
		{
			f_cmFreeLook.m_XAxis.m_MaxSpeed = 300;
			f_cmFreeLook.m_YAxis.m_MaxSpeed = 2;
		}
		else
		{
			f_cmFreeLook.m_XAxis.m_MaxSpeed = 0;
			f_cmFreeLook.m_YAxis.m_MaxSpeed = 0;
		}
	}
}
