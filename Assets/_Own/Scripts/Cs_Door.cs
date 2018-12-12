using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Door : MonoBehaviour, Is_Interactable<Transform>
{
	//static GameObject[] sf_Players; //all players, used to RPC
	//static Transform f_Player; //the player, used to RPC
	[SerializeField] int f_rotationSpeed; //how fast the door opens
	[SerializeField] bool f_isLocked; //whether the door is opened or closed
	Rigidbody f_rigidbody;
	
	void Awake()
	{
		f_rigidbody = GetComponent<Rigidbody>();
	}

	public void M_Action(Transform v_transform)
	{
		f_rigidbody.AddRelativeForce(
			transform.position - v_transform.position,
			ForceMode.Acceleration);
	}

	void OnMouseDown()
    {
		print("CKICK");
        f_rigidbody.AddRelativeForce(0,0,-50);
    }

}
