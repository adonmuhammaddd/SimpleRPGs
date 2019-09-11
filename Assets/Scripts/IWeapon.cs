/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
	#region Variables

	List<BaseStat> Stats { get; set; }
	int CurrentDamage { get; set; }

	#endregion

	void PerformAttack(int damage);
	void PerformSpecialAttack();
}
