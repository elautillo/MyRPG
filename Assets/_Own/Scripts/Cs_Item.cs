using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Item : MonoBehaviour, Is_Interactable<Cs_Player>
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void M_Action(Cs_Player p_player)
	{
		p_player.M_GetInventory().M_StoreItem(this);
	}
}
