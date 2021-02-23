using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnemy : Trigger
{
	public Collider2D boundary;

	public override void CheckDistance() {
		if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius && boundary.bounds.Contains(target.transform.position)) {
    		if(currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger) {
	    		Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
	    		changeAnim(temp - transform.position);
	    		myRigidbody.MovePosition(temp);
	    		ChangeState(EnemyState.walk);
	    		anim.SetBool("trigger", true);
	    	}
    	}
    	else if(Vector3.Distance(target.position, transform.position) > chaseRadius || !boundary.bounds.Contains(target.transform.position)) {
	    	/*ChangeState(EnemyState.idle);*/
	    	anim.SetBool("trigger", false);
	    }
	}
}
