using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cs_Inventory : MonoBehaviour
{
	const int Cf_INVENTORY_SIZE = 4;
    [SerializeField] Cs_Item f_emptyItem;
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


    void M_Fill()
    {
        string v_itemType;

        for (int i = 0; i < Cf_INVENTORY_SIZE; i++)
        {
            v_itemType = Ps_DataStore.GetSavedItem(i);

            if (v_itemType != "")
            {
                M_StoreItem(v_itemType);
            }
            else f_items[i] = Instantiate(f_emptyItem);
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
			if (f_items[i].GetComponents<Component>().Length < 3)
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
