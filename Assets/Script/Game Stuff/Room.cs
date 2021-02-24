using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{	
	public Enemy[] enemies;

	public virtual void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Player") && !other.isTrigger) {
			for(int i = 0; i < enemies.Length; i++) {
				ChangeActivation(enemies[i], true);
			}
		}
	}

	public virtual void OnTriggerExit2D(Collider2D other) {
		if(other.CompareTag("Player") && !other.isTrigger) {
			for(int i = 0; i < enemies.Length; i++) {
				ChangeActivation(enemies[i], false);
			}
		}
	}

	public void ChangeActivation(Component component, bool activation) {
		component.gameObject.SetActive(activation);
	}
}
