using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Powerup {

	public FloatValue knightHealth;
	public FloatValue heartContainers;
	public float amountToIncrease;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other) {
    	if(other.CompareTag("Player") && !other.isTrigger) {
    		knightHealth.RuntimeValue += amountToIncrease;
    		if(knightHealth.initialValue > heartContainers.RuntimeValue *2f) {
    			knightHealth.initialValue = heartContainers.RuntimeValue * 2f;
    		}
    		powerupSignal.Raise();
    		Destroy(this.gameObject);
    	}
    }
}
