﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    public Boss boss;
    public HealthBarBoss healthBoss;

	public virtual void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Player") && !other.isTrigger) {
				boss.gameObject.SetActive(true);
				healthBoss.gameObject.SetActive(true);
		}
	}
}
