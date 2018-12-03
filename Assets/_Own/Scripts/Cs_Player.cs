using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Player : MonoBehaviour
{
	RaycastHit f_Hit;

    void M_Interact()
    {
        if (Physics.Raycast(transform.position, transform.forward, out f_Hit, 3)
            && Input.GetKeyDown(Ps_Input.C_INTERACTION_KEY))
        {
            f_Hit.transform.GetComponent<Is_Interactable>().M_Action();
        }
    }
}
