using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState {
	idle, attack, stagger, dead
}

public class Boss : MonoBehaviour
{

	[Header("State Machine")]
	public BossState currentState;
	
	[Header("Boss Stats")]
	public int maxHealth = 10;
	public float currentHealth;
	public HealthBarBoss healthBar;
	public float moveSpeed;
	public float attackRadius;

	[Header("Boss Stuff")]
	public Rigidbody2D myRigidbody;
	public Transform target;
	public Animator anim;
	

    void Start()
    {
    	currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        currentState = BossState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate(){
    	if(currentHealth > 0) {
        	CheckDistance();
        }
    }


	private void TakeDamage(float damage) {
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
		if(currentHealth <= 0) {
			/*DeathEffect();*/
			currentState = BossState.dead;
			anim.SetBool("dead", true);
			StartCoroutine(Destroy());
		}
	}

	private IEnumerator Destroy() {
    	yield return new WaitForSeconds(2.8f);
    	this.gameObject.SetActive(false);
    	healthBar.SetActiveFalse();
    }


	public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage) {
		StartCoroutine(KnockCo(myRigidbody, knockTime));
		TakeDamage(damage);
	}

	private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime) {
    	if(myRigidbody != null) {
    		yield return new WaitForSeconds(knockTime);
    		myRigidbody.velocity = Vector2.zero;
    		currentState = BossState.idle;
    		myRigidbody.velocity = Vector2.zero; 
    	}
    }

    public virtual void CheckDistance() {
    	if(Vector3.Distance(target.position, transform.position) > attackRadius) {
	    	if(currentState == BossState.idle && currentState != BossState.stagger && currentState != BossState.dead) {
		    	Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
		    	changeAnim(temp - transform.position);
		    	myRigidbody.MovePosition(temp);
	    	}
	    }
	    else {
	    	if(currentState == BossState.idle && currentState != BossState.stagger && currentState != BossState.dead) {
	    		StartCoroutine(AttackCo());
	    	}
	    }
    }

    public IEnumerator AttackCo() {
    	currentState = BossState.attack;
    	anim.SetBool("attack", true);
    	yield return new WaitForSeconds(1f);
    	currentState = BossState.idle;
    	anim.SetBool("attack", false);
    }

    private void SetAnimFloat(Vector2 setVector) {
    	anim.SetFloat("moveX", setVector.x);
    	/*anim.SetFloat("moveY", setVector.y);*/
    }

    public void changeAnim(Vector2 direction) {
    	if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
    		if(direction.x > 0) {
    			SetAnimFloat(Vector2.right);
    		}
    		else if(direction.x < 0) {
    			SetAnimFloat(Vector2.left);
    		}
    	}	
	}

	public void ChangeState(BossState newState) {
    	if(currentState != newState) {
    		currentState = newState;
    	}
    }
}
