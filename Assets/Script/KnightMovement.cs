using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KnightState {
    walk, attack, interact, stagger, idle
}
public class KnightMovement : MonoBehaviour
{
    public KnightState currentState;
   	public float speed;
   	private Vector3 change;
   	private Rigidbody2D myRigidbody;
   	private Animator animator;

    void Start()
    {
        currentState = KnightState.walk;
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", 0);
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("attack") && currentState != KnightState.attack && currentState != KnightState.stagger) {
            StartCoroutine(AttackCo());
        }
        else if(currentState == KnightState.walk || currentState == KnightState.idle) {
            UpdateAnimationAndMove();
        }
    }

    private IEnumerator AttackCo() {
        animator.SetBool("attacking", true);
        currentState = KnightState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = KnightState.walk;
    }

    void UpdateAnimationAndMove() {
    	if(change != Vector3.zero) {
        	MoveCharacter();
        	animator.SetFloat("moveX", change.x);
        	animator.SetBool("moving", true);
        }
        else {
        	animator.SetBool("moving", false);
        }
    }

    void MoveCharacter() {
        change.Normalize();
    	myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    public void Knock(float knockTime) {
        StartCoroutine(KnockCo(knockTime));
    }

    private IEnumerator KnockCo(float knockTime) {
        if(myRigidbody != null) {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = KnightState.idle;
            myRigidbody.velocity = Vector2.zero; 
        }
    }

}
