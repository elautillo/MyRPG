using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Item : MonoBehaviour
{
	[SerializeField] Cs_Drop f_drop;


	void Start()
	{
		
	}
	

	void Update()
	{
		
	}

	
	public void M_Drop(Vector3 p_position)
	{
		f_drop.GetComponent<Renderer>().enabled = true;
		f_drop.transform.position = p_position;
	}
}
