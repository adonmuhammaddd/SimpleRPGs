/*
* Copyright (c) Adon
* http://instagram.com/_adonmuhammaddd
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
	#region Variables

	public GameObject playerHand;

	public GameObject EquippedWeapon { get; set; }

	Item currentlyEquippedItem;
	Transform spawnProjectile;
	IWeapon equippedWeapon;
	CharacterStats characterStats;

	#endregion

	#region Unity Methods

	void Start()
    {
		spawnProjectile = transform.Find("ProjectileSpawn");
		characterStats = GetComponent<Player>().characterStats;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
		{
			PerformWeaponAttack();
		}
		if (Input.GetKeyDown(KeyCode.Z))
		{
			PerformWeaponSpecialAttack();
		}
	}

    #endregion

	public void EquipWeapon(Item itemToEquip)
	{
		if (EquippedWeapon != null)
		{
			UnequipWeapon();
		}

		EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);
		equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
		if (EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
		{
			EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = spawnProjectile;
		}

		EquippedWeapon.transform.SetParent(playerHand.transform);
		equippedWeapon.Stats = itemToEquip.Stats;
		currentlyEquippedItem = itemToEquip;
		characterStats.AddStatBonus(itemToEquip.Stats);

		UIEventHandler.ItemEquipped(itemToEquip);
		UIEventHandler.StatsChanged();
	}

	public void UnequipWeapon()
	{
		InventoryController.Instance.GiveItem(currentlyEquippedItem.ObjectSlug);
		characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
		Destroy(playerHand.transform.GetChild(0).gameObject);
		UIEventHandler.StatsChanged();
	}

	public void PerformWeaponAttack()
	{
		equippedWeapon.PerformAttack(CalculateDamage());
	}

	public void PerformWeaponSpecialAttack()
	{
		equippedWeapon.PerformSpecialAttack();
	}

	private int CalculateDamage()
	{
		int damageToDeal = (characterStats.GetStat(BaseStat.BaseStatType.Power).GetCalculatedStatValue() * 2) + Random.Range(2, 8);
		damageToDeal += CalculateCrit(damageToDeal);
		Debug.Log("Damage Dealt : " + damageToDeal);
		return damageToDeal;
	}

	private int CalculateCrit(int damage)
	{
		if (Random.value <= .10f)
		{
			int critDamage = (int)(damage * Random.Range(.25f, .5f));
			return critDamage;
		}
		return 0;
	}
}
