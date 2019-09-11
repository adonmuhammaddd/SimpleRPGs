/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	#region Variables

	public GameObject monster;
	public bool respawn;
	public float spawnDelay;
	private float currentTime;
	private bool spawning;

    #endregion

    #region Unity Methods
    
    void Start()
    {
		Spawn();
		currentTime = spawnDelay;
    }

    void Update()
    {
        if (spawning)
		{
			currentTime -= Time.deltaTime;
			if (currentTime <= 0)
			{
				Spawn();
			}
		}
    }

    #endregion

	public void Respawn()
	{
		spawning = true;
		currentTime = spawnDelay;
	}

	void Spawn()
	{
		IEnemy instance = Instantiate(monster, transform.position, Quaternion.identity).GetComponent<IEnemy>();
		instance.Spawner = this;
		spawning = false;
	}
}
