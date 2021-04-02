using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum KnightState {
    walk, attack, interact, stagger, idle, dead, win
}
public class KnightMovement : MonoBehaviour
{
    [Header("State Machine")]
    public KnightState currentState;

    [Header("Player Stats")]
   	public float speed;
    public FloatValue currentHealth;
    public Inventory knightInventory;

    [Header("Player Stuff")]
    public Signal knightHit;
    public SpriteRenderer receivedItemSprite;
    public Signal knightHealthSignal;
    private Vector3 change;
    public Rigidbody2D myRigidbody;
    public Animator animator;
    public GameManagement game;

    void Start()
    {
        currentState = KnightState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", 0);
        FindObjectOfType<AudioManager>().Play("Dungeon");
    }

    // Update is called once per frame
    void Update()
    {   
        //is the player is an interaction
        if(currentState == KnightState.interact) {
            return;
        }
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("attack") && currentState != KnightState.attack && currentState != KnightState.stagger && currentState != KnightState.dead) {
            StartCoroutine(AttackCo());
        }
        else if(currentState == KnightState.walk || currentState == KnightState.idle) {
            UpdateAnimationAndMove();
        }
    }

    private IEnumerator AttackCo() {
        animator.SetBool("attacking", true);
        currentState = KnightState.attack;
        FindObjectOfType<AudioManager>().Play("KnightAttack");
        yield return new WaitForSeconds(.4f);
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        if(currentState != KnightState.interact) {
            currentState = KnightState.idle;
        }
    }

    public void RaiseItem() {
        if(knightInventory.currentItem != null) {
            if(currentState != KnightState.interact) {
                animator.SetBool("receive item", true);
                currentState = KnightState.interact;
                receivedItemSprite.sprite = knightInventory.currentItem.itemSprite;
            }
            else {
                animator.SetBool("receive item", false);
                currentState = KnightState.idle;
                receivedItemSprite.sprite = null;
            }
        }
    }

    void UpdateAnimationAndMove() {
        if(change != Vector3.zero) {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetBool("moving", true);
        }
        else {
            currentState = KnightState.idle;
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter() {
        change.Normalize();
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
        currentState = KnightState.walk;
    }

    public void Knock(float knockTime, float damage) {
        currentHealth.RuntimeValue -= damage;
        FindObjectOfType<AudioManager>().Play("KnightDamage");
        knightHealthSignal.Raise();
        if(currentHealth.RuntimeValue > 0) {
            StartCoroutine(KnockCo(knockTime));
        }
        else {
            currentState = KnightState.dead;
            animator.SetBool("dead", true);
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            game.gameWinOrDefeat();
            StartCoroutine(Destroy());
        }
    }

    private IEnumerator KnockCo(float knockTime) {
        knightHit.Raise();
        if(myRigidbody != null || currentState != KnightState.dead) {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = KnightState.idle;
            myRigidbody.velocity = Vector2.zero; 
        }
    }

    private IEnumerator Destroy() {
        yield return new WaitForSeconds(1.2f);
        this.gameObject.SetActive(false);
        SceneManager.LoadScene("GameOver");
    }
}
