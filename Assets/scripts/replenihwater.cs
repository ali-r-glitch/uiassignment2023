using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replenihwater : MonoBehaviour
{
    helikoter heli;
    GameObject player;
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="player")
        {
            player = other.gameObject;
            heli = player.GetComponent<helikoter>();
            heli.water = 100;
        }
    }
}
