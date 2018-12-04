using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Door : MonoBehaviour, Is_Interactable
{
	static GameObject[] sf_Players; //all players, used to RPC
	static Transform f_Player; //the player, used to RPC
	Vector3 f_StartRot; //the door's starting rotation
	Vector3 f_NewRot; //the door's new (open) rotation
	[SerializeField] int f_RotateSpeed; //how fast the door opens
	bool f_Opened; //whether the door is opened or closed

	void Awake()
	{
		f_Opened = false;
		f_StartRot = transform.rotation.eulerAngles;
	}

	public void M_Action()
	{
		//if door is shut
		if (!f_Opened)
		{
			//while door's rotation is not equal to the new rotation
			Vector3 v_MyRot = new Vector3(0, 0, 0);

			while (transform.rotation.eulerAngles != f_NewRot)
			{
				//rotate door
				transform.rotation.eulerAngles = Vector3.MoveTowards(
					transform.rotation.eulerAngles,
					f_NewRot,
					Time.deltaTime * f_RotateSpeed);

				float v_DistanceBetween = Vector3.Distance(
					transform.rotation.eulerAngles,
					f_NewRot);

				if (v_DistanceBetween < 0.1)
				{
					break;
				}
				
				//if object doesn't lerp... for whatever reason
				if (v_MyRot != transform.rotation.eulerAngles)
				{
					v_MyRot = transform.rotation.eulerAngles;
				}
				else
				{
					transform.rotation.eulerAngles = f_StartRot;

					break;
				}
				yield;
			}
			//when while loop ends, opened is true
			f_Opened = true;
		}//if door is open
		else
		{
			//while door's rotation is not equal to its starting rotation
			Vector3 v_MyRot = new Vector3(0, 0, 0);

			while (transform.rotation.eulerAngles != f_StartRot)
			{
				//rotate door
				transform.rotation.eulerAngles = Vector3.MoveTowards(
					transform.rotation.eulerAngles,
					f_StartRot,
					Time.deltaTime * f_RotateSpeed);

				distanceBetween = Vector3.Distance(
					transform.rotation.eulerAngles,
					f_StartRot);

				if (distanceBetween < 0.1)
				{
					break;
				}
				
				//if object doesn't lerp... for whatever reason
				if (v_MyRot != transform.rotation.eulerAngles)
				{
					v_MyRot = transform.rotation.eulerAngles;
				}
				else
				{
					transform.rotation.eulerAngles = f_StartRot;

					break;
				}
				yield;
			}
			//when while loop ends, opened is false
			f_Opened = false;
		}
	}
}
