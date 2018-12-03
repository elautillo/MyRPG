using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Player : MonoBehaviour
{
	private RaycastHit v_hit;

    private void M_Interact()
    {
        if (Physics.Raycast(transform.position, transform.forward, out v_hit, 3))
        {
            if (Input.GetKeyDown(C_InputController.V_INTERACTION_KEY))
            {
                v_hit.transform.GetComponent<C_Interactable>().M_Action();
            }
        }
    }
}
