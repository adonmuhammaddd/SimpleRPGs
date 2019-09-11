/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
	#region Variables

	[HideInInspector]
	public NavMeshAgent playerAgent;
	private bool hasInteracted;
	bool isEnemy;

	#endregion

	#region Unity Methods

	void Update()
	{
		if (!hasInteracted && playerAgent != null && !playerAgent.pathPending)
		{
			if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
			{
				if (!isEnemy)
				{
					Interact();
				}
				EnsureLookDirection();
				hasInteracted = true;
			}
		}
	}

	#endregion

	public virtual void MoveToInteraction(NavMeshAgent playerAgent)
	{
		isEnemy = gameObject.tag == "Enemy";
		hasInteracted = false;
		this.playerAgent = playerAgent;
		playerAgent.stoppingDistance = 3f;
		playerAgent.destination = this.transform.position;
	}

	public virtual void Interact()
	{
		Debug.Log("Interacting with base class.");
	}

	void EnsureLookDirection()
	{
		playerAgent.updateRotation = false;
		Vector3 lookDirection = new Vector3(transform.position.x, playerAgent.transform.position.y, transform.position.z);
		playerAgent.transform.LookAt(lookDirection);
		playerAgent.updateRotation = true;
	}
}
