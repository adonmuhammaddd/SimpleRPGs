/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	#region Variables

	public CharacterStats characterStats;

	public int currentHealth;
	public int maxHealth;

	public PlayerLevel PlayerLevel { get; set; }

	#endregion

	#region Unity Methods

	void Start()
    {
		PlayerLevel = GetComponent<PlayerLevel>();
		this.currentHealth = this.maxHealth;
		characterStats = new CharacterStats(10, 10, 10);
    }

    void Update()
    {
        
    }

    #endregion

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			Die();
		}
		UIEventHandler.HealthChanged(this.currentHealth, this.maxHealth);
	}

	private void Die()
	{
		Debug.Log("Player Dead. Reset Health.");
		this.currentHealth = this.maxHealth;
		UIEventHandler.HealthChanged(this.currentHealth, this.maxHealth);
	}
}
