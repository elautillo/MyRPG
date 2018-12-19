using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Player : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int f_score;
    [SerializeField] float f_dropHeight = 0.1f;

    Cs_Inventory f_inventory;
    RaycastHit f_hit;


    void Awake()
    {
        f_inventory = GetComponentInChildren<Cs_Inventory>();
    }


    void Start()
    {
        
    }


    void Update()
    {
        M_CheckInput();
    }


    void M_CheckInput()
    {
       if (Input.GetKeyDown(Ps_Input.GetUseItemKey()))
       {
           M_UseItem();
       }
       else if (Input.GetKeyDown(Ps_Input.GetInteractionKey()))
       {
           M_Interact();
       }
       else if (Input.GetKeyDown(Ps_Input.GetNextItemKey()))
       {
           f_inventory.M_ChangeItem(true);
       }
       else if (Input.GetKeyDown(Ps_Input.GetPreviousItemKey()))
       {
           f_inventory.M_ChangeItem(false);
       }
       else if (Input.GetKeyDown(Ps_Input.GetDropItemKey()))
       {
           f_inventory.M_DropItem(
               transform.position + new Vector3(0, f_dropHeight, 0));
       }
    }


    void M_UseItem()
    {
        f_inventory.M_GetActiveItem().M_Use();
    }
    

    void M_Interact()
    {
        //Debug.DrawRay(transform.position, transform.forward * 100, Color.red, 10);

        if (Physics.Raycast(transform.position, transform.forward, out f_hit, 3))
        {
            print(f_hit.transform.gameObject.name);
            
            Is_Interactable<Cs_Player> v_interactableTarget =
                f_hit.transform.GetComponent<Is_Interactable<Cs_Player>>();

            if (v_interactableTarget != null)
            {
                print(Ps_Debug.GetInteractingMessage());

                v_interactableTarget.M_Interaction(this);
            }
            else print(Ps_Debug.GetNonInteractableMessage());
        }
        else print(Ps_Debug.GetNoDetectionMessage());
    }


    public int M_GetHealth()
    {
        return health;
    }


    public int M_GetScore()
    {
        return f_score;
    }


    public Cs_Inventory M_GetInventory()
    {
        return f_inventory;
    }
}
