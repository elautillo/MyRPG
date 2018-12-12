using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Door : MonoBehaviour, Is_Interactable
{
	[SerializeField] bool f_isLocked = true;
	Rigidbody f_rigidbody;
	

	void Awake()
	{
		f_rigidbody = GetComponent<Rigidbody>();
	}


	public void M_Action()
	{
		// f_rigidbody.AddRelativeForce(
		// 	transform.position - v_transform.position,
		// 	ForceMode.Acceleration);

		if ()
		{
			f_isLocked = !f_isLocked;
		}
	}


	void OnMouseDown()
    {
		print("CKICK");
        f_rigidbody.AddRelativeForce(0, 0, -50);
    }
}
