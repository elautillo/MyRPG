using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Player : MonoBehaviour
{
	RaycastHit f_hit;

// lo de la llaveeeeeeeeeeeeeeeeeeeeee
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

        if (Physics.Raycast(transform.position, transform.forward, out f_hit, 3))
        {
            print(f_hit.transform.gameObject.name);
            
            Is_Interactable v_interactableTarget =
                f_hit.transform.GetComponent<Is_Interactable>();

            if (v_interactableTarget != null)
            {
                print(Ps_Debug.Cf_INTERACTING_MESSAGE);

                v_interactableTarget.M_Action();
            }
            else print(Ps_Debug.Cf_NON_INTERACTABLE_MESSAGE);
        }
        else print(Ps_Debug.Cf_NO_DETECTION_MESSAGE);
    }
}
