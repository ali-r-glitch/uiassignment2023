using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helikoter : MonoBehaviour
{

    public float rotationspeed;
    
    public bool landed;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += transform.up * Time.deltaTime * 6;
        }
        else
        {
            transform.position += transform.up * Time.deltaTime * -3;
        }
        if (!landed)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * Time.deltaTime * 6;

            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -rotationspeed, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, rotationspeed, 0);
            }
        }
    }
}
