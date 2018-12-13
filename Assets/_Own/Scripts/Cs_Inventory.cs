using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Inventory : MonoBehaviour
{
	const int Cf_INVENTORY_SIZE = 4;
    [SerializeField] int f_activeItem = 0;
	[SerializeField] Cs_Item[] f_items = new Cs_Item[Cf_INVENTORY_SIZE];


	void Start()
	{
        M_Fill();
		M_ActivateItem();
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


    public Cs_Item[] M_GetItems()
    {
        return f_items;
    }


    public int M_GetSize()
    {
        return Cf_INVENTORY_SIZE;
    }


    void M_Fill()
    {
        for (int i = 0; i < Cf_INVENTORY_SIZE; i++)
        {
            string v_itemType = Cs_DataStore.GetSavedItem(i);

            if (v_itemType != "")
            {
                M_StoreItem(v_itemType);
            }
            else f_items[i] = new Cs_Item();
        }
    }


    public void M_StoreItem(string p_itemType)
    {
        for (int i = 0; i < Cf_INVENTORY_SIZE; i++)
		{
			if (f_items[i].GetComponents<Component>().Length < 3)
			{
				f_items[i] = GetComponent(p_itemType) as Cs_Item;
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
