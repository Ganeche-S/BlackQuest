using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : Interactable {

	public Item contents;
	public Inventory knightInventory;
	public bool isOpen;
	public Signal raiseItem;
	public GameObject dialogBox;
	public Text dialogText;
	private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("o") && playerInRange) {
        	if(!isOpen) {
        		//Ouvrir le coffre
        		OpenChest();
        	}
        	else {
        		//Coffre deja ouvert
        		ChestAlreadyOpen();
        	}
        } 
    }

    public void OpenChest() {
    	//Dialog window on
    	dialogBox.SetActive(true);
    	//dialog window = contents text
    	dialogText.text = contents.itemDescription;
    	//add contents to the inventory
    	knightInventory.AddItem(contents);
    	knightInventory.currentItem = contents;
    	//Raise the signal to the player to animate
    	raiseItem.Raise();
    	//raise the context clue
    	context.Raise();
    	//set the chest to opened
	    isOpen = true;
	    anim.SetBool("opened", true);
    }

    public void ChestAlreadyOpen() {
	    //Dialog off
	    dialogBox.SetActive(false);
	    //raise the signal to the player to stop animating
	    raiseItem.Raise();
	    //set the current item to empty
	    knightInventory.currentItem = null;
    }

    private void OnTriggerEnter2D(Collider2D other) {
    	if(other.CompareTag("Player") && !other.isTrigger && !isOpen) {
    		context.Raise();
    		playerInRange = true;
    	}
    }

    private void OnTriggerExit2D(Collider2D other) {
    	if(other.CompareTag("Player") && !other.isTrigger && !isOpen) {
    		context.Raise();
    		playerInRange = false;
    	}
    }
}
