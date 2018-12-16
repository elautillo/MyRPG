using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cs_Inventory : MonoBehaviour
{
	const int Cf_INVENTORY_SIZE = 4;
    [SerializeField] Cs_Item f_emptyItem;
    [SerializeField] Cs_Key f_key;
    [SerializeField] Cs_LifePot f_lifePot;
    [SerializeField] Cs_ManaPot f_manaPot;
    [SerializeField] Cs_Shield f_shield;
    [SerializeField] Cs_Staff f_staff;
    [SerializeField] Cs_Sword f_sword;
    [SerializeField] int f_activeItem = 0;
	[SerializeField] string[] f_itemTypes = new string[Cf_INVENTORY_SIZE];


	void Start()
	{
        M_Fill();
		M_ActivateItem();
	}


	void Update()
	{
		
	}


    void M_Fill()
    {
        string v_itemType;
        string v_keyType = f_key.GetType().ToString();
        string v_lifePotType = f_lifePot.GetType().ToString();
        string v_manaPotType = f_manaPot.GetType().ToString();
        string v_shieldType = f_shield.GetType().ToString();
        string v_staffType = f_staff.GetType().ToString();
        string v_swordType = f_sword.GetType().ToString();

        for (int i = 0; i < Cf_INVENTORY_SIZE; i++)
        {
            v_itemType = Ps_DataStore.GetSavedItem(i);

            if (v_itemType == "")
            {
                f_itemTypes[i] = "";
            }    
            else if (v_itemType == v_keyType)
            {
                f_key.transform.parent = transform;
                f_itemTypes[i] = v_keyType;
            }
            else if (v_itemType == v_lifePotType)
            {
                f_lifePot.transform.parent = transform;
                f_itemTypes[i] = v_lifePotType;
            }
            else if (v_itemType == v_manaPotType)
            {
                f_manaPot.transform.parent = transform;
                f_itemTypes[i] = v_manaPotType;
            }
            else if (v_itemType == v_shieldType)
            {
                f_shield.transform.parent = transform;
                f_itemTypes[i] = v_shieldType;
            }
            else if (v_itemType == v_staffType)
            {
                f_staff.transform.parent = transform;
                f_itemTypes[i] = v_staffType;
            }
            else if (v_itemType == v_swordType)
            {
                f_sword.transform.parent = transform;
                f_itemTypes[i] = v_swordType;
            }
        }
    }


    public void M_ActivateItem()
    {
        Renderer v_renderer;

        M_DeactivateItems();

        v_renderer = f_items[f_activeItem].gameObject.GetComponent<Renderer>();

        if (v_renderer != null)
        {
            v_renderer.enabled = true;
        }
    }


    public void M_DeactivateItems()
    {
        Renderer v_renderer;

        for (int i = 0; i < Cf_INVENTORY_SIZE; i++)
        {
            v_renderer = f_items[i].gameObject.GetComponent<Renderer>();

            if (v_renderer != null)
            {
                v_renderer.enabled = false;
            }
        }
    }


    public void M_StoreItem(string p_itemType)
    {
        for (int i = 0; i < Cf_INVENTORY_SIZE; i++)
		{
			if (f_itemTypes[i] != "")
			{
				f_items[i] = GetComponent(p_itemType) as Cs_Item;
                f_activeItem = i;
                return;
			}
		}
        M_ActivateItem();
    }


    public void M_ChangeItem(bool p_next)
    {
        if (f_activeItem < Cf_INVENTORY_SIZE - 1 && f_activeItem > 0)
        {
            if (p_next)
            {
                for (int i = f_activeItem + 1; i < Cf_INVENTORY_SIZE; i++)
                {
                    if (f_items[i].GetComponents<Component>().Length > 2)
                    {
                        f_activeItem = i;
                        return;
                    }
                }
            }
            else
            {
                for (int i = f_activeItem - 1; i >= 0; i--)
                {
                    if (f_items[i].GetComponents<Component>().Length > 2)
                    {
                        f_activeItem = i;
                        return;
                    }
                }
            }
            M_ActivateItem();
        }
    }


    public void M_DropItem(Vector3 p_position)
    {
        f_items[f_activeItem].M_Drop(p_position);
        f_items[f_activeItem] = new Cs_Item();

        for (int i = f_activeItem; i < Cf_INVENTORY_SIZE; i++)
        {
            if (f_items[i].GetComponents<Component>().Length > 2)
            {
                f_activeItem = i;
                return;
            }
        }
        M_ActivateItem();
    }


    public Cs_Item M_GetActiveItem()
    {
        return f_items[f_activeItem];
    }


    public Cs_Item[] M_GetAllItems()
    {
        return f_items;
    }


    public int M_GetSize()
    {
        return Cf_INVENTORY_SIZE;
    }
}
