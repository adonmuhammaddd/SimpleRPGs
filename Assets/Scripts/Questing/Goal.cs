/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
	#region Variables
	public Quest Quest { get; set; }

	public string Description { get; set; }
	public bool Completed { get; set; }
	public int CurrentAmount { get; set; }
	public int RequiredAmount { get; set; }
	#endregion

	public virtual void Init()
	{
		// default init stuff
	}

	public void Evaluate()
	{
		if (CurrentAmount >= RequiredAmount)
		{
			Complete();
		}
	}

	public void Complete()
	{
		Quest.CheckGoals();
		Completed = true;
	}
}
