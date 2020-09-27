using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    Health health;
    public float damage=100f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            health = collision.GetComponent<Health>();
            health.TakeDamage(damage);
        }
    }
}