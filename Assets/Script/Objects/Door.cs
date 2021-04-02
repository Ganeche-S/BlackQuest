using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType {
	key, enemy, button
}
public class Door : Interactable
{	
	[Header("Door variables")]
	public DoorType thisDoorType;
	public bool open = false;
	public Inventory playerInventory;
	public SpriteRenderer doorSprite;
	public BoxCollider2D physicsCollider;
	public BoxCollider2D trigger;

	private void Update() {
		if(Input.GetKeyDown(KeyCode.Return)) {
			if(playerInRange && thisDoorType == DoorType.key) {
				//Le joueur a t'il une clé
				if(playerInventory.numberOfKeys > 0) {
					//Enlever une clé depuis l'inventaire du joueur
					playerInventory.numberOfKeys--;
					//Si c vrai, on appelle la méthode pour ouvrir la porte
					Open();
					FindObjectOfType<AudioManager>().Play("Door");
				}
				
			}
		}
	}

	public void Open() {
		//Enlever le sprite de la porte fermé
		doorSprite.enabled = false;
		//Mettre le bool de l'ouverture de la porte en true
		open = true;
		//Enlever le box collider de la porte
		physicsCollider.enabled = false;
		trigger.enabled = false;
	}

	public void Close() {
		//Mettre le sprite de la porte fermé
		doorSprite.enabled = true;
		//Mettre le bool de l'ouverture de la porte en false
		open = false;
		//Mettre le box collider de la porte
		physicsCollider.enabled = true;
		trigger.enabled = true;
	}
}
