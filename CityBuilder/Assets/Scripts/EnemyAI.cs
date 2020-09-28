using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public Collider2D col;
    public Animator animator;
    public float maxDist = 5f;
    
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(player == null) { return; }
        Vector2 dir = (Vector2)player.position - rb.position;
        if(animator != null)
        {
            if (dir.x <= 0)
            {
                animator.SetFloat("Horizontal", -1f);
            }
            else if (dir.x > 0)
            {
                animator.SetFloat("Horizontal", 1f);
            }
        }
        movement = dir.normalized;
    }
    void FixedUpdate()
    {
        if(Vector2.Distance(rb.position, (Vector2)player.position)<= maxDist)
        {
            Movement(movement);
        }
            
        
        
        

    }
    public void Movement(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(10);
        }
        if (collision.gameObject.tag == "Ally")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(10);
        }
    }
}
