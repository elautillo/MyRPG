using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Door : MonoBehaviour, Is_Interactable<Cs_Player>
{
	[SerializeField] Cs_Item f_key;
	Rigidbody f_rigidbody;


	void Awake()
	{
		f_rigidbody = GetComponent<Rigidbody>();
		f_rigidbody.constraints = RigidbodyConstraints.FreezeRotationY;
	}


	public void M_Interaction(Cs_Player p_player)
	{
		// f_rigidbody.AddRelativeForce(
		// 	transform.position - v_transform.position,
		// 	ForceMode.Acceleration);

		if (p_player.M_GetInventory().M_GetActiveItem() == f_key)
		{
			f_rigidbody.constraints = RigidbodyConstraints.None;
		}
	}
}
