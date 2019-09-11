/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
	#region Variables

	public static DialogueSystem Instance { get; set; }

	public GameObject dialoguePanel;

	public List<string> dialogueLines = new List<string>();
	public string npcName;

	Button continueButton;
	Text dialogueText, nameText;
	int dialogueIndex;

	#endregion

	#region Unity Methods

	void Awake()
    {
		continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
		dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
		nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();

		continueButton.onClick.AddListener(delegate { ContinueDialogue(); });
		dialoguePanel.SetActive(false);

        if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}
    }

    void Update()
    {
        
    }

    #endregion

	public void AddNewDialogue(string[] lines, string npcName)
	{
		dialogueIndex = 0;
		dialogueLines = new List<string>();
		foreach (string line in lines)
		{
			dialogueLines.Add(line);
		}
		this.npcName = npcName;

		CreateDialogue();
	}

	public void CreateDialogue()
	{
		dialogueText.text = dialogueLines[0];
		nameText.text = npcName;
		dialoguePanel.SetActive(true);
	}

	public void ContinueDialogue()
	{
		if (dialogueIndex < dialogueLines.Count-1)
		{
			dialogueIndex++;
			dialogueText.text = dialogueLines[dialogueIndex];
		}
		else
		{
			dialoguePanel.SetActive(false);
		}
	}
}
