using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helikoter : MonoBehaviour
{

    public float rotationspeed;
    [SerializeField] private Transform blades;
    public bool landed;
    public float throttle,water=100f;
    private float rotorspeed=10f, throttleant = 25f;
    private float bufferdip = 0;
    private bool playsound=false;
    private AudioSource enginesiund;
    public AudioClip helicoptersound;

    // Start is called before the first frame update


    // Update is called once per frame
    private void Start()
    {
        enginesiund = GetComponent<AudioSource>();
        enginesiund.clip = helicoptersound;

    }
    void Update()
    {
        throttle = Mathf.Clamp(throttle, 0, 100);
        blades.Rotate(Vector3.up * throttle * rotorspeed);
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += transform.up * Time.deltaTime * 6;
            throttle += Time.deltaTime * throttleant;
        }
        else
        {
            transform.position += Vector3.up * Time.deltaTime * -3;
           throttle -= (Time.deltaTime * throttleant)/4;
        }
        if(landed)
        {
           
            enginesiund.Stop();
            playsound = false;
            
        }
        if (!landed)
        {
            if (!playsound)
            {
                enginesiund.Play();
                playsound = true;
            }

           

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -rotationspeed, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.localRotation.eulerAngles.y, 0), 1f);


            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, rotationspeed, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, transform.localRotation.eulerAngles.y, 0), 1f);

            }
            if (Input.GetKey(KeyCode.W))
            {
             
                bufferdip += 2*Time.deltaTime;
                bufferdip = Mathf.Clamp(bufferdip, 0, 10);
                transform.position += transform.forward * Time.deltaTime * 6;

                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(bufferdip, transform.localRotation.eulerAngles.y, 0), 10f);
                //bufferundip = bufferdip;
            }
            else
            {
               
                bufferdip -= 2*Time.deltaTime;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(bufferdip, transform.localRotation.eulerAngles.y, 0f), 10f);
                bufferdip = Mathf.Clamp(bufferdip, 0, 10);
                // bufferdip = bufferundip;
            }


        }



    }
}
