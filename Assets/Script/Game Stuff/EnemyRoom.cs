using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoom : Room
{	
	public Door[] doors;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CheckEnemies() {
    	for(int i = 0; i < enemies.Length; i++) {
    		if(enemies[i].gameObject.activeInHierarchy && i < enemies.Length -1) {
    			return;
    		}
    	}
    	OpenDoor();
    }

    public override void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Player") && !other.isTrigger) {
			for(int i = 0; i < enemies.Length; i++) {
				ChangeActivation(enemies[i], true);
			}
		}
		CloseDoor();
	}

	public override void OnTriggerExit2D(Collider2D other) {
		if(other.CompareTag("Player") && !other.isTrigger) {
			for(int i = 0; i < enemies.Length; i++) {
				ChangeActivation(enemies[i], false);
			}
		}
	}

    public void CloseDoor() {
    	for(int i = 0; i < doors.Length; i++) {
    		doors[i].Close();
    	}
    }

    public void OpenDoor() {
    	for(int i = 0; i < doors.Length; i++) {
    		doors[i].Open();
    	}
    }
}
