using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Checkpoint : MonoBehaviour, Is_Interactable<Cs_Player>
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void M_Interaction(Cs_Player p_player)
	{
		if (p_player.M_GetInventory().M_GetCount() > 0)
		{
			Ps_DataStore.StoreAll(
				p_player.transform.position,
				p_player.M_GetScore(),
				p_player.M_GetInventory().M_GetAllItems(),
				p_player.M_GetInventory().M_GetSize());
		}
	}
}
