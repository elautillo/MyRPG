﻿using System.Collections;
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

        if (Physics.Raycast(transform.position, transform.forward, out f_hit, 3))
        {
            if (f_hit.collider != null)
            {
                Transform v_target = f_hit.transform;

                print(v_target.gameObject.name);
                
                if (v_target.GetComponent<Is_Interactable<Transform>>() != null)
                {
                    print(Ps_Debug.Cf_INTERACTING_MESSAGE);

                    v_target.GetComponent<Is_Interactable<Transform>>().
                        M_Action(transform);
                }
                else print(Ps_Debug.Cf_NON_INTERACTABLE_MESSAGE);
            }
            else print(Ps_Debug.Cf_NO_DETECTION_MESSAGE);
        }
    }
}
