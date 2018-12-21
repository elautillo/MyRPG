using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_ClearDataButton : MonoBehaviour
{
	public void ClearAllData()
	{
		Ps_DataStore.ClearData();
	}
}
