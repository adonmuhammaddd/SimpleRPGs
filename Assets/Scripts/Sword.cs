/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sword : MonoBehaviour, IWeapon
{
	#region Variables

	private Animator animator;
	public List<BaseStat> Stats { get; set; }
	public CharacterStats CharacterStats { get; set; }
	public int CurrentDamage { get; set; }

	#endregion

	#region Unity Methods

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	#endregion

	public void PerformAttack(int damage)
	{
		CurrentDamage = damage;
		animator.SetTrigger("Base_Attack");
	}

	public void PerformSpecialAttack()
	{
		animator.SetTrigger("Special_Attack");
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Enemy")
		{
			col.GetComponent<IEnemy>().TakeDamage(CurrentDamage);
		}
	}
}
