using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    float currentHealth;
    public GameObject[] Items;
    int rand;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Player")
            {
                Debug.Log("Player is dead");
                gameObject.GetComponent<Movement>().enabled = false;
            }
            else if (gameObject.tag == "Enemy")
            {
                Debug.Log("Player is dead");
                ItemDrop();
            }
        }
    }

    void ItemDrop()
    {
        rand = Random.Range(0, Items.Length);
        if (Items[rand] == null)
            Debug.Log("No items to drop");
        else
            Instantiate(Items[rand], transform.position, Quaternion.identity);

        Destroy(gameObject, .1f);
    }
}
