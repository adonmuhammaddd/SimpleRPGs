﻿/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{
	#region Variables

	public bool AssignedQuest { get; set; }
	public bool Helped { get; set; }

	[SerializeField] private GameObject quests;
	[SerializeField] private string questType;
	private Quest Quest { get; set; }

	#endregion

	public override void Interact()
	{
		if (!AssignedQuest && !Helped)
		{
			base.Interact();
			AssignQuest();
		}
		else if (AssignedQuest && !Helped)
		{
			CheckQuest();
		}
		else
		{

		}
	}

	void AssignQuest()
	{
		AssignedQuest = true;
		Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
	}

	void CheckQuest()
	{
		if (Quest.Completed)
		{
			Quest.GiveReward();
			Helped = true;
			AssignedQuest = false;
			DialogueSystem.Instance.AddNewDialogue(new string[] {"Thanks for that!"}, name);
		}
		else
		{
			DialogueSystem.Instance.AddNewDialogue(new string[] { "You're still in the middle of helping me. Get back at it."}, name);
		}
	}
}
