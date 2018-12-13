using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Ps_ObjectNames : MonoBehaviour
{
	const string Cf_KEY_ITEM_NAME = "Key";


	void Start()
	{
		
	}


	public static string GetKeyItemName()
	{
		return Cf_KEY_ITEM_NAME;
	}
}
