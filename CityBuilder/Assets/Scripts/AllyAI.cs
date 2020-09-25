using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AllyAI : MonoBehaviour
{
    public Transform Follow;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public Collider2D col;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Follow = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            Follow = GameObject.FindGameObjectWithTag("Enemy").transform;
        }
        Vector2 dir = (Vector2)Follow.position - rb.position;
        
        movement = dir.normalized;
    }
    void FixedUpdate()
    {
        Movement(movement); 
    }
    public void Movement(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(10);
        }
        if(collision.gameObject.tag == "Player")
        {
            movement = Vector2.zero;
        }
    }
    
}
