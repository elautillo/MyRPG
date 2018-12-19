using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Droper : MonoBehaviour, Is_Interactable<Cs_Player>
{
	[SerializeField] GameObject f_worldItems;
	int counter = 0;

	public void M_Interaction(Cs_Player p_player)
	{
		f_worldItems.GetComponentsInChildren<Cs_Item>()[counter].GetComponent<MeshRenderer>().enabled = true;
		f_worldItems.GetComponentsInChildren<Cs_Item>()[counter].transform.position = p_player.transform.position;
		counter++;
		GetComponent<Collider>().enabled = false;
	}
}
