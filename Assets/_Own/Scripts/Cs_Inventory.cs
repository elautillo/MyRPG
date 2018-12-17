using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cs_Inventory : MonoBehaviour
{
    const int Cf_INVENTORY_SIZE = 4;
    [SerializeField] int f_activeItem = 0;
	[SerializeField] List<Cs_Item> f_items = new List<Cs_Item>();
    [SerializeField] GameObject f_worldItems;


	void Start()
	{
        Ps_DataStore.ClearData();
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

                f_items[i] = GetComponents<Cs_Item>()[i];
            }
        }
        print(f_items.Count);
        M_DisableRenderers(1);
        M_DisableRenderers(2);
        if (f_items.Count > 0) M_ActivateItem();
    }


    void M_DisableRenderers(int p_param) //Cs_Item[] p_items, Component p_component
    {
        switch (p_param)
        {
            case 1:
                foreach (var l_item in GetComponents<Cs_Item>())
                {
                    l_item.
                        GetComponent<MeshRenderer>().enabled = false;
                }
            break;
            
            case 2:
                foreach (var l_item in f_worldItems.GetComponents<Cs_Item>())
                {
                    l_item.
                        GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
                }
            break;

            case 3:
                foreach (var l_item in GetComponents<Cs_Item>())
                {
                    l_item.
                        GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
                }
            break;
        }
    }


    public void M_ActivateItem()
    {
        M_DisableRenderers(3);
        f_items[f_activeItem].gameObject.
            GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
    }


    public void M_StoreItem(Cs_Item p_item)
    {
        if (f_items.Count < Cf_INVENTORY_SIZE)
        {
            p_item.transform.parent = transform;
            p_item.transform.position = transform.position;

            p_item.GetComponent<MeshRenderer>().enabled = false;
            p_item.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;

            f_activeItem = Cf_INVENTORY_SIZE -1;
            M_ActivateItem();
        }
        else print("Your inventory is full.");
    }


    public void M_DropItem(Vector3 p_position)
    {
        f_items[f_activeItem].transform.parent = f_worldItems.transform;
        f_items[f_activeItem].transform.position = p_position;

        f_items[f_activeItem].
            GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        f_items[f_activeItem].
            GetComponent<MeshRenderer>().enabled = true;
        
        if (Cf_INVENTORY_SIZE > 0)
        {
            if (Cf_INVENTORY_SIZE <= f_activeItem)
            {
                f_activeItem--;
            }
            M_ActivateItem();
        }
    }


    public void M_ChangeItem(bool p_next)
    {
        if (f_activeItem < Cf_INVENTORY_SIZE - 1 && f_activeItem > 0)
        {
            if (p_next) f_activeItem++; else f_activeItem--;
            M_ActivateItem();
        }
        else print("No more items this way.");
    }


    public Cs_Item M_GetActiveItem()
    {
        return f_items[f_activeItem];
    }


    public List<Cs_Item> M_GetAllItems()
    {
        return f_items;
    }


    public int M_GetSize()
    {
        return Cf_INVENTORY_SIZE;
    }
}
