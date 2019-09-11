/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionLog : MonoBehaviour, IConsumable
{
	public void Consume()
	{
		Debug.Log("You drank a swig of the potion. Cool!");
		Destroy(gameObject);
	}

	public void Consume(CharacterStats stats)
	{
		Debug.Log("You drank a swig of the potion. Cool!");
	}
	#region Variables

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
