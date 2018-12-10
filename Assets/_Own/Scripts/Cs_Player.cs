using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Player : MonoBehaviour
{
	RaycastHit f_hit;

    void Update()
    {
        M_CheckInput();
    }

    void M_CheckInput()
    {
       if (Input.GetKeyDown(Ps_Input.Cf_PLAYER_INTERACTION_KEY))
       {
           M_Interact();
       }
    }

    void M_Interact()
    {
        //Debug.DrawRay(transform.position, transform.forward * 100, Color.red, 10);

        if (Physics.Raycast(
            transform.position,
            transform.forward,
            out f_hit,
            Mathf.Infinity))
        {
            print(f_hit.transform.gameObject.name);
            
            if (f_hit.transform.GetComponent<Is_Interactable<Transform>>() != null)
            {
                f_hit.transform.GetComponent<Is_Interactable<Transform>>().M_Action(transform);
            }
        }
    }
}
