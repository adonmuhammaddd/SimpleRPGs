/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalController : MonoBehaviour
{
	#region Variables
	[SerializeField]
	private Button button;
	private Portal[] portal;
	private Player player;
	private GameObject panel;

    #endregion

    #region Unity Methods
    
    void Start()
    {
		player = FindObjectOfType<Player>();
		panel = transform.Find("Panel_Portal").gameObject;
    }

    void Update()
    {
		
    }

    #endregion

	public void ActivatePortal(Portal[] portals)
	{
		panel.SetActive(true);
		for (int i = 0; i < portals.Length ; i++)
		{
			Button portalButton = Instantiate(button, panel.transform);
			portalButton.GetComponentInChildren<Text>().text = portals[i].name;
			int x = i;
			portalButton.onClick.AddListener(delegate { OnPortalButtonClick(x, portals[x]); });
		}
	}

	void OnPortalButtonClick(int portalIndex, Portal portal)
	{
		player.transform.position = portal.TeleportLocation;
		panel.SetActive(false);
	}
}
