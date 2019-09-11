/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDatabase : MonoBehaviour
{
    #region Variables

	public static ItemDatabase Instance { get; set; }

	private List<Item> Items { get; set; }

    #endregion

    #region Unity Methods
    
    void Awake()
    {
        if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}
		BuildDatabase();
    }

    void Update()
    {
		
    }

    #endregion

	private void BuildDatabase()
	{
		Items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("JSON/Items").ToString());
		Debug.Log(Items[1].ItemName + " is a" + Items[1].ItemType.ToString());
		Debug.Log(Items[0].ItemName);
	}

	public Item GetItem(string itemSlug)
	{
		foreach (Item item in Items)
		{
			if (item.ObjectSlug == itemSlug)
			{
				return item;
			}
		}
		Debug.LogWarning("Coudln't find item : " + itemSlug);
		return null;
	}
}
