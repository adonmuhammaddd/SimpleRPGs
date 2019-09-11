/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableController : MonoBehaviour
{
	#region Variables

	CharacterStats stats;

    #endregion

    #region Unity Methods
    
    void Start()
    {
		stats = GetComponent<Player>().characterStats;
    }

    void Update()
    {
        
    }

    #endregion

	public void ConsumeItem(Item item)
	{
		GameObject itemToSpawn = Instantiate(Resources.Load<GameObject>("Consumables/" + item.ObjectSlug));
		if (item.ItemModifier)
		{
			itemToSpawn.GetComponent<IConsumable>().Consume(stats);
		}
		else
		{
			itemToSpawn.GetComponent<IConsumable>().Consume();
		}		
	}
}
