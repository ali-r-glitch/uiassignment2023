using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicshelicopter : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float respomsiveness;
    [SerializeField] private float rotorspeed=10f,throttleant = 25f;
    private float throttle, roll, pitch, yaw;
    [SerializeField] private Transform blades;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();


    }
    private void Update()
    {
       
        blades.Rotate(Vector3.up*throttle*rotorspeed);
        
    }
    private void FixedUpdate()
    {

        handleinput();
        rb.AddForce(transform.up * throttle, ForceMode.Impulse);
        rb.AddTorque(transform.right * pitch * respomsiveness);
        rb.AddTorque(-transform.forward * roll * respomsiveness);
        rb.AddTorque(transform.up *yaw  * respomsiveness);
    
    }
    private void handleinput()
    {
        roll = Input.GetAxis("Horizontal");
        pitch = Input.GetAxis("Vertical");
        yaw = Input.GetAxis("yaw");
        if(Input.GetKey(KeyCode.Space))

        {
           
            throttle += Time.deltaTime * throttleant;
        }else if (Input.GetKey(KeyCode.LeftShift))
        {
            throttle -= Time.deltaTime * throttleant;
        }
        throttle = Mathf.Clamp(throttle, 0, 100);
    }
}