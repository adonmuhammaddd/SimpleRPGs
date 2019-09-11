/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEvents : MonoBehaviour
{
	#region Variables
	public delegate void EnemyEventHandler(IEnemy enemy);
	public static event EnemyEventHandler OnEnemyDeath;

	public static void EnemyDied(IEnemy enemy)
	{
		if (OnEnemyDeath != null)
		{
			OnEnemyDeath(enemy);
		}
	}
	#endregion

	#region Unity Methods

	void Start()
    {
        
    }

    void Update()
    {
        
    }

	#endregion
}
