/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	#region Variables

	public RectTransform inventoryPanel;
	public RectTransform scrollViewContent;
	InventoryUIItem itemContainer { get; set; }
	bool menuIsActive { get; set; }
	Item currentSelectedItem { get; set; }

    #endregion

    #region Unity Methods
    
    void Start()
    {
		itemContainer = Resources.Load<InventoryUIItem>("UI/Item_Container");
		UIEventHandler.OnItemAddedToInventory += ItemAdded;

		inventoryPanel.gameObject.SetActive(false);
    }

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.I))
		{
			menuIsActive = !menuIsActive;
			inventoryPanel.gameObject.SetActive(menuIsActive);
		}
	}

    #endregion

	public void ItemAdded(Item item)
	{
		InventoryUIItem emptyItem = Instantiate(itemContainer);
		emptyItem.SetItem(item);
		emptyItem.transform.SetParent(scrollViewContent);
	}
}
