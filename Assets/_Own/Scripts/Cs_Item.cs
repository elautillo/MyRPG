using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Item : MonoBehaviour, Is_Interactable<Cs_Player>
{
	int f_rotation = 0;
	[SerializeField] int f_speed = 1;


	public virtual void Start()
	{

	}
	

	public virtual void Update()
	{
		transform.position = transform.position;
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
