using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landed : MonoBehaviour
{
    // Start is called before the first frame update
    public helikoter hp;
    private void Start()
    {
        Debug.Log("ok");
    }

    private void OnTriggerEnter(Collider other)
    {
   
        Debug.Log(other.tag);
        
        if (other.gameObject.tag!= "Player")
        {
            hp.landed = true;
            Debug.Log("Untagged");
        }

    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag != "Player")
        {
            hp.landed = false;
            Debug.Log("Untagged");
        }
    }
}
