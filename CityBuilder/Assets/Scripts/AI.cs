using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public Collider2D col;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        Vector2 dir = (Vector2)player.position - rb.position;
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
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Damage Here");
        }
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Damage Here");
        }
    }
}
