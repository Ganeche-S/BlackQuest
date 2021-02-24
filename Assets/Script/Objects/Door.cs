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

	private void Update() {
		if(Input.GetKeyDown("o")) {
			if(playerInRange && thisDoorType == DoorType.key) {
				//Le joueur a t'il une clé
				if(playerInventory.numberOfKeys > 0) {
					//Enlever une clé depuis l'inventaire du joueur
					playerInventory.numberOfKeys--;
					//Si c vrai, on appelle la méthode pour ouvrir la porte
					Open();
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
	}

	public void Close() {
		//Enlever le sprite de la porte fermé
		doorSprite.enabled = true;
		//Mettre le bool de l'ouverture de la porte en true
		open = false;
		//Enlever le box collider de la porte
		physicsCollider.enabled = true;
	}
}
