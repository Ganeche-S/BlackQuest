using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : Trigger
{	
	public GameObject projectile;
	public float fireDelay;
	private float fireDelaySeconds;
	public bool canFire = true;

	private void Update() {
		fireDelaySeconds -= Time.deltaTime;
		if(fireDelay <= 0) {
			canFire = true;
			fireDelaySeconds = fireDelay;
		}
	}

	public override void CheckDistance() {
	    if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius) {
    		if(currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger) {
    			if(canFire = true) {
		    		Vector3 tempVector = target.transform.position - transform.position;
		    		GameObject current = Instantiate(projectile, transform.position, Quaternion.identity);
		    		current.GetComponent<Projectile>().Launch(tempVector);
		    		canFire = false;
		    		ChangeState(EnemyState.walk);
		    		anim.SetBool("trigger", true);
		    	}
	    	}
    	}
    	else if(Vector3.Distance(target.position, transform.position) > chaseRadius) {
	    	/*ChangeState(EnemyState.idle);*/
	    	anim.SetBool("trigger", false);
	    }
	}
}
