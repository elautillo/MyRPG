using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Cs_Inventory : MonoBehaviour
{
    const int Cf_INVENTORY_SIZE = 4;
    int f_count = 0;
    [SerializeField] int f_activeItem = 0;
	[SerializeField] Cs_Item[] f_items = new Cs_Item[Cf_INVENTORY_SIZE];
    [SerializeField] GameObject f_worldItems;
    [SerializeField] GameObject f_itemIcons;
    [SerializeField] GameObject f_iconSlots;


	void Start()
	{
        M_Fill();
	}


    void M_Fill()
    {
        string v_itemName;
        GameObject v_item;
        
        for (int i = 0; i < Cf_INVENTORY_SIZE; i++)
        {
            v_itemName = Ps_DataStore.GetSavedItem(i);
 
            if (v_itemName != "")
            {
                v_item = GameObject.Find(v_itemName);

                v_item.transform.parent = transform;
                v_item.transform.position = transform.position;

                f_count++;
            }
        }
        f_items = GetComponentsInChildren<Cs_Item>();

        for (int i = 0; i < f_count; i++)
        {
            M_ManageIcons(i, i);
        }

        foreach (var l_item in GetComponentsInChildren<Cs_Item>())
        {
            l_item.
                GetComponent<MeshRenderer>().enabled = false;
        }

        foreach (var l_item in f_worldItems.GetComponentsInChildren<Cs_Item>())
        {
            l_item.
                GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            l_item.
                GetComponent<MeshRenderer>().enabled = false;
        }
        if (f_count > 0) M_ActivateItem();
    }


    public void M_ActivateItem()
    {
        foreach (var l_item in GetComponentsInChildren<Cs_Item>())
        {
            l_item.
                GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        }
        f_items[f_activeItem].gameObject.
            GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
    }


    public void M_StoreItem(Cs_Item p_item)
    {
        if (f_count < Cf_INVENTORY_SIZE)
        {
            p_item.transform.parent = transform;
            p_item.transform.position = transform.position;

            p_item.GetComponent<MeshRenderer>().enabled = false;
            p_item.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;

            f_items = GetComponentsInChildren<Cs_Item>();
            f_count++;

            for (int i = 0; i < f_count; i++)
            {
                M_ManageIcons(i, i);
            }

            f_activeItem = f_count -1;
            M_ActivateItem();
        }
        else print("Your inventory is full.");
    }


    public void M_DropItem(Vector3 p_position)
    {
        if (f_count > 0)
        {
            f_items[f_activeItem].transform.parent = f_worldItems.transform;
            f_items[f_activeItem].transform.position = p_position;

            f_items[f_activeItem].
                GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            f_items[f_activeItem].
                GetComponent<MeshRenderer>().enabled = true;

            f_items = GetComponentsInChildren<Cs_Item>();
            f_count--;

            for (int i = 0; i < f_count; i++)
            {
                M_ManageIcons(i, i);
            }

            M_ManageIcons(f_count, 6);
        
            if (f_activeItem > 0)
            {
                f_activeItem--;
                M_ActivateItem();
            }
        }
        else print("Your inventory is empty.");
    }


    public void M_ChangeItem(bool p_next)
    {
        if (f_count > 0)
        {
            if (p_next)
            {
                if (f_activeItem < f_count - 1)
                {
                    f_activeItem++;
                }
                else print("No newer items.");

                M_ActivateItem();
            }
            else
            {
                if (f_activeItem > 0)
                {
                    f_activeItem--;
                }
                else print("No older items.");

                M_ActivateItem();
            }
        }
        else print("Your inventory is empty.");
    }


    void M_ManageIcons(int p_index1, int p_index2)
    {
        f_iconSlots.GetComponentsInChildren<Image>()[p_index1].sprite =
                    f_itemIcons.GetComponentsInChildren<Image>()[p_index2].sprite;
    }


    public Cs_Item M_GetActiveItem()
    {
        if (f_count > 0)
        {
            return f_items[f_activeItem];
        }
        else
        {
            print("No active items.");
            return new Cs_Item();
        }
    }


    public Cs_Item[] M_GetAllItems()
    {
        return f_items;
    }


    public int M_GetSize()
    {
        return Cf_INVENTORY_SIZE;
    }


    public int M_GetCount()
    {
        return f_count;
    }
}
