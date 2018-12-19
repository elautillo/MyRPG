using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Sword : Cs_Item, Is_Damaging<int>
{
	public override void Start () {
		base.Start();
	}
	

	public override void Update () {
		base.Update();
	}


	public void M_DealDamage(int p_damage)
	{
		
	}

	public override void M_Use()
	{
		GetComponentInParent<Cs_Player>();
	}
}
