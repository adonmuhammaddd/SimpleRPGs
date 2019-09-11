/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour
{
	#region Variables

	public List<Goal> Goals { get; set; }
	public string QuestName { get; set; }
	public string Description { get; set; }
	public int ExperienceReward { get; set; }
	public Item ItemReward { get; set; }
	public bool Completed { get; set; }

	#endregion

	#region Unity Methods

	void Start()
    {
        
    }

    void Update()
    {
        
    }

    #endregion

	public void CheckGoals()
	{
		Completed = Goals.All(g => g.Completed);
	}

	public void GiveReward()
	{
		if (ItemReward != null)
		{
			InventoryController.Instance.GiveItem(ItemReward);
		}
	}
}
