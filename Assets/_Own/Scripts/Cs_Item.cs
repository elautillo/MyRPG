using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Item : MonoBehaviour
{
	int f_rotation = 0;
	[SerializeField] int f_speed = 1;
	Rigidbody f_rigidbody;


	void Start()
	{
		f_rigidbody = GetComponent<Rigidbody>();
		f_rigidbody.constraints = RigidbodyConstraints.FreezePosition;
	}
	

	void Update()
	{
		M_Rotate();
	}


	public void M_Action(Cs_Player p_player)
	{
		transform.parent = p_player.transform;
        f_itemTypes[i] = v_swordType;
	}

	
	public void M_Drop(Vector3 p_position)
	{
		f_drop.GetComponent<Renderer>().enabled = true;
		f_drop.transform.position = p_position;
	}
}
