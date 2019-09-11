﻿/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIItem : MonoBehaviour
{
	#region Variables

	public Item item;
	public Text itemText;
	public Image itemImage;

    #endregion

    #region Unity Methods
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #endregion

	public void SetItem(Item item)
	{
		this.item = item;
		SetupItemValues();
	}

	void SetupItemValues()
	{
		itemText.text = item.ItemName;
		itemImage.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.ObjectSlug);
	}

	public void OnSelectItemButton()
	{
		InventoryController.Instance.SetItemDetails(item, GetComponent<Button>());
	}
}
