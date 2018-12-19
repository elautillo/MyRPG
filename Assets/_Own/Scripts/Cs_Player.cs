using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cs_Player : MonoBehaviour
{
    [SerializeField] int f_health = 100;
    [SerializeField] Text f_healthText;
    [SerializeField] int f_score = 0;
    [SerializeField] Text f_scoreText;
    [SerializeField] float f_dropHeight = 0.1f;

    Cs_Inventory f_inventory;
    RaycastHit f_hit;
    int difficulty;


    void Awake()
    {
        f_inventory = GetComponentInChildren<Cs_Inventory>();
        difficulty = Ps_DataStore.GetDifficulty();
    }


    void Start()
    {
        InvokeRepeating("M_GetDamage", 2, 2);
    }


    void Update()
    {
        f_healthText.text = "Health: " + f_health.ToString();
        f_scoreText.text = "Total Score: " + f_score.ToString();

        M_CheckInput();
        
        if (f_health <= 0) M_Die();

        if (f_inventory.GetComponentsInChildren<Cs_Item>().Length >= difficulty) M_Win();
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
                GetComponent<AudioSource>().Play();
                M_AddScore(10);
                if(v_interactableTarget.GetType() == typeof(Cs_Item))
                {
                    M_AddScore(90);
                }
            }
            else print(Ps_Debug.GetNonInteractableMessage());
        }
        else print(Ps_Debug.GetNoDetectionMessage());
    }


    void M_GetDamage()
    {
        f_health = f_health - 1;
    }


    void M_Die()
    {
        SceneManager.LoadScene(3);
    }


    public int M_GetHealth()
    {
        return f_health;
    }


    public int M_GetScore()
    {
        return f_score;
    }


    public void M_AddScore(int p_bonusScore)
    {
        f_score = f_score + p_bonusScore;
    }


    public Cs_Inventory M_GetInventory()
    {
        return f_inventory;
    }


    void M_Win()
    {
        Ps_DataStore.StoreResult(1);
        SceneManager.LoadScene(3);
    }
}
