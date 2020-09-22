using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeongenerator : MonoBehaviour
{
    public int openingDir;
    private RoomTemp temp;
    int rand;
    bool spawned = false;

    public float waitTime=4f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, waitTime);
        temp = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemp>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn()
    {
        if (spawned == false)
        {
            if (openingDir == 1)
            {
                rand = Random.Range(0, temp.bottomRooms.Length);
                Instantiate(temp.bottomRooms[rand], transform.position, temp.bottomRooms[rand].transform.rotation);
            }
            else if (openingDir == 2)
            {
                rand = Random.Range(0, temp.topRooms.Length);
                Instantiate(temp.topRooms[rand], transform.position, temp.topRooms[rand].transform.rotation);
            }
            else if (openingDir == 3)
            {
                rand = Random.Range(0, temp.leftRooms.Length);
                Instantiate(temp.leftRooms[rand], transform.position, temp.leftRooms[rand].transform.rotation);
            }
            else if (openingDir == 4)
            {
                rand = Random.Range(0, temp.rightRooms.Length);
                Instantiate(temp.rightRooms[rand], transform.position, temp.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpawnPoint"))
        {
            if (collision.CompareTag("SpawnPoint"))
            {
                if(collision.GetComponent<Dungeongenerator>().spawned=false&& spawned == false)
                {
                    Instantiate(temp.closedroom, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                spawned = true;
            }
            
        }
    }
}
