/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileWeapon
{
	#region Variables

	Transform ProjectileSpawn { get; set; }

	void CastProjectile();

	#endregion
}
