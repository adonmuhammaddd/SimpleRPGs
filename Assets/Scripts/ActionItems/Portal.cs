/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : ActionItem
{
	#region Variables

	public Vector3 TeleportLocation { get; set; }
	[SerializeField] private Portal[] linkedPortals;
	private PortalController PortalController { get; set; }

	#endregion

	#region Unity Methods

	void Start()
    {
		PortalController = FindObjectOfType<PortalController>();
		TeleportLocation = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z);
    }

    void Update()
    {
        
    }

	#endregion

	public override void Interact()
	{
		PortalController.ActivatePortal(linkedPortals);
	}
}
