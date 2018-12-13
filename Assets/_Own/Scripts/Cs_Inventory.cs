using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Inventory : MonoBehaviour
{
	const int Cf_INVENTORY_SIZE = 9;
	[SerializeField] int f_activeItem = 0;
	[SerializeField] Cs_Item[] f_items = new Cs_Item[Cf_INVENTORY_SIZE];


	void Start()
	{
		M_ActivateItem();

        for (int i = 0; i < Cf_INVENTORY_SIZE; i++)
        {
            f_items[i] = Instantiate(Resources.LoadAssetAtPath("Examplepath/" + Cs_DataStore.GetSavedItem(i));
        }
	}


	void Update()
	{
		
	}


    public void M_ActivateItem()
    {
        M_DeactivateItems();
        f_items[f_activeItem].gameObject.SetActive(true);
    }


    public void M_DeactivateItems()
    {
        foreach (var l_item in f_items)
        {
            l_item.gameObject.SetActive(false);
        }
    }


    public string M_GetActiveItemName()
    {
        return f_items[f_activeItem].gameObject.name;
    }


    public string[] M_GetItemNames()
    {
        string[] v_itemNames = null; // controlar nulls

        for (int i = 0; i < Cf_INVENTORY_SIZE; i++)
        {
            v_itemNames[i] = f_items[i].gameObject.name;
        }
        return v_itemNames;
    }


    public Cs_Item[] M_GetItems()
    {
        return f_items;
    }


    public int M_GetInventorySize()
    {
        return Cf_INVENTORY_SIZE;
    }


    public void M_StoreItem(Cs_Item p_item)
    {
        for (int i = 0; i < Cf_INVENTORY_SIZE; i++)
		{
			if (f_items[i] == null)
			{
				f_items[i] = p_item;
                return;
			}
		}
    }


    public void M_ChangeItem(bool p_next)
    {
        if (f_activeItem < Cf_INVENTORY_SIZE -1 && f_activeItem > 0)
        {
            if (p_next)
            {
                f_activeItem++;
            }
            else
            {
                f_activeItem--;
            }
            M_ActivateItem();
        }
    }


    public void M_DropItem(Vector3 p_position)
    {
        f_items[f_activeItem].transform.position = p_position;
    }
}
