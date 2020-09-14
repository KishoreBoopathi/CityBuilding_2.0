using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact
}
public class Movement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D rb;
    Vector3 movement;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", 1);
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Fire1") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk)
        {
            AnimAndMovement();
        }
    }

    private void FixedUpdate()
    {
       
        
    }
    IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;

    }
    void AnimAndMovement()
    {
        if (movement != Vector3.zero)
        {
            Movement2d();
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void Movement2d()
    {
        movement.Normalize();
        rb.MovePosition(transform.position +movement  * speed * Time.deltaTime);
    }
}
