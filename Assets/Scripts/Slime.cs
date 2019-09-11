/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : MonoBehaviour, IEnemy
{
	#region Variables

	public float currentHealth;
	public float maxHealth;
	public LayerMask aggroLayerMask;

	public int ID { get; set; }

	public int Experience { get; set; }
	public DropTable DropTable { get; set; }
	public Spawner Spawner { get; set; }
	public PickupItem pickupItem;

	private Player player;
	private NavMeshAgent navAgent;
	private CharacterStats characterStats;
	private Collider[] withinAggroColliders;
	
	#endregion

	void Start()
	{
		DropTable = new DropTable();
		DropTable.loot = new List<LootDrop>
		{
			new LootDrop("sword", 25),
			new LootDrop("staff", 25),
			new LootDrop("potion_log", 25)
		};
		ID = 0;
		Experience = 20;
		navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		characterStats = new CharacterStats(6, 10, 2);
		currentHealth = maxHealth;
	}

	void FixedUpdate()
	{
		withinAggroColliders = Physics.OverlapSphere(transform.position, 10, aggroLayerMask);
		if (withinAggroColliders.Length > 0)
		{
			ChasePlayer(withinAggroColliders[0].GetComponent<Player>());
		}
	}

	public void PerformAttack()
	{
		player.TakeDamage(5);
	}

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void ChasePlayer(Player player)
	{
		navAgent.SetDestination(player.transform.position);
		this.player = player;
		if (navAgent.remainingDistance <= navAgent.stoppingDistance)
		{
			if (!IsInvoking("PerformAttack"))
			{
				InvokeRepeating("PerformAttack", .5f, 2f);
			}
		}
		else
		{
			CancelInvoke("PerformAttack");
		}
	}

	public void Die()
	{
		DropLoot();
		CombatEvents.EnemyDied(this);
		this.Spawner.Respawn();
		Destroy(gameObject);
	}

	void DropLoot()
	{
		Item item = DropTable.GetDrop();
		if (item != null)
		{
			PickupItem instance = Instantiate(pickupItem, transform.position, Quaternion.identity);
			instance.ItemDrop = item;
		}
	}
}
