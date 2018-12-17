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


	void M_Rotate()
	{
		f_rotation += f_speed;
		transform.rotation = Quaternion.Euler(new Vector3(0, f_rotation, 0));
	}


	public void M_Action(Cs_Player p_player)
	{
        p_player.M_GetInventory().M_StoreItem(this);
	}
}
