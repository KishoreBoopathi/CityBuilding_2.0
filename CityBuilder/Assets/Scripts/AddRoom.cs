using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemp temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemp>();
        temp.rooms.Add(this.gameObject);
    }

}
