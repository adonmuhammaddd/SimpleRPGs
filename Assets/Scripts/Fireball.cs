﻿/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
	#region Variables

	public Vector3 Direction { get; set; }
	public float Range { get; set; }
	public int Damage { get; set; }

	Vector3 spawnPosition;

	#endregion

	#region Unity Methods

	void Start()
    {
		Range = 20f;
		Damage = 4;
		spawnPosition = transform.position;
		GetComponent<Rigidbody>().AddForce(Direction * 50f);
    }

    void Update()
    {
        if (Vector3.Distance(spawnPosition, transform.position) >= Range)
		{
			Extinguish();
		}
    }

	#endregion

	private void OnCollisionEnter(Collision col)
	{
		if (col.transform.tag == "Enemy")
		{
			col.transform.GetComponent<IEnemy>().TakeDamage(Damage);
		}
		Extinguish();
	}

	void Extinguish()
	{
		Destroy(gameObject);
	}
}
