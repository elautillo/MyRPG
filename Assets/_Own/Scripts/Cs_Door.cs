using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Door : MonoBehaviour, Is_Interactable<Cs_Player>
{
	Rigidbody f_rigidbody;
	

	void Awake()
	{
		f_rigidbody = GetComponent<Rigidbody>();
		f_rigidbody.constraints = RigidbodyConstraints.FreezeRotationY;
	}


	public void M_Action(Cs_Player p_player)
	{
		// f_rigidbody.AddRelativeForce(
		// 	transform.position - v_transform.position,
		// 	ForceMode.Acceleration);

		if (p_player.M_GetInventory().M_GetActiveItemName() ==
			Ps_ObjectNames.GetKeyItemName())
		{
			f_rigidbody.constraints = RigidbodyConstraints.None;
		}
	}


	// void OnMouseDown()
    // {
	// 	print("CKICK");
    //     f_rigidbody.AddRelativeForce(0, 0, -50);
    // }
}
