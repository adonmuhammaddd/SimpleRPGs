/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPost : ActionItem
{
	#region Variables

	public string[] dialogue;

    #endregion

    #region Unity Methods
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

	#endregion

	public override void Interact()
	{
		DialogueSystem.Instance.AddNewDialogue(dialogue, "Sign");
		Debug.Log("Interaction with sign post.");


	}
}
