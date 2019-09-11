/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateSlayer : Quest
{
    #region Variables

    #endregion

    #region Unity Methods
    
    void Start()
    {
		QuestName = "Ultimate SLayer";
		Description = "Kill a bunch of stuff";
		ItemReward = ItemDatabase.Instance.GetItem("potion_log");
		ExperienceReward = 100;

		Goals = new List<Goal>();
		Goals.Add(new KillGoal(this, 0, "Kill 5 Slimes", false, 0, 2));
		Goals.Add(new KillGoal(this, 1, "Kill 2 Vampires", false, 0, 2));

		Goals.ForEach(g => g.Init());
    }

    void Update()
    {
        
    }

    #endregion
}
