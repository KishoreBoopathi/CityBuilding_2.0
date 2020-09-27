using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float health;
    public float currentHealth;
    public GameObject[] Items;
    int rand;
    bool isPlayer;
    GameObject enemy;
    public Text healthUI;
    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = health;
        if(gameObject.tag == "Player")
        {
            isPlayer = true;
        }
        else
        {
            isPlayer = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TakeDamage(20);
            }
        }
        if(gameObject.tag == "Player")
        {
            healthUI.text = currentHealth.ToString("f0") + "/100";
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
                SceneManager.LoadScene(FindObjectOfType<Player_Stats>().BDungeon);
            }
            else if (gameObject.tag == "Enemy")
            {
                Debug.Log("Enemy is dead");
                ItemDrop();
            }
            if (gameObject.tag == "Ally")
            {
                Debug.Log("Ally is dead");
                gameObject.GetComponent<Movement>().enabled = false;
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
