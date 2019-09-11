/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
	#region Variables

	public string[] dialogue;
	public string name;

    #endregion

	public override void Interact()
	{
		DialogueSystem.Instance.AddNewDialogue(dialogue, name);
		Debug.Log("Interacting with NPC.");
	}
}
