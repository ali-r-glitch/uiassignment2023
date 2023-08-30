using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isonfire;

    private float maxhealth,current,maybefire = 0;
    public int randomnum,randomnum2,probabl=20;
    private GameObject canvas,player,wall1, wall2, wall3, wall4;
    private GameObject cllisioonabove;
    private abovethebuilding abv;
    private helikoter hk;
    private GameObject cam,smoke;
    private AudioSource aud;
    private float fireputout;
    private GameObject playerwaterparticles;
    

    
    
         

    // Update is called once per frame\

    private void Start()
    {
       
        aud = GetComponent<AudioSource>();
        cam = GameObject.Find("Main Camera");
        canvas = (transform.FindChild("Canvas")).gameObject;
        player = GameObject.Find("player");
        playerwaterparticles = GameObject.Find("waterfallholder");
        playerwaterparticles.SetActive(false);
        Debug.Log(playerwaterparticles.name);

        cllisioonabove = transform.Find("above").gameObject;
        hk = player.GetComponent<helikoter>();
        abv = cllisioonabove.GetComponent<abovethebuilding>();
        foreach (Transform child in transform)
        {
            if (child.CompareTag("wall1"))
            {
                wall1 = child.gameObject;
              
            }
            if (child.CompareTag("wall2"))
            {
                wall2 = child.gameObject;

            }
            if (child.CompareTag("wall3"))
            {
                wall3 = child.gameObject;

            }
            if (child.CompareTag("wall4"))
            {
                wall4 = child.gameObject;

            }
            if (child.CompareTag("smoke"))
            {
                smoke = child.gameObject;

            }
        }
        
    }

    void ignitebuilding()
    {
        // Find the child with the specified tag

        
        canvas.SetActive(true);
        current = maxhealth;
        burningbuilding();
        smoke.SetActive(true);
        aud.Play();

    }


    public void burningbuilding()
    {
      
        wall1.transform.localScale += new Vector3(0, 0.05f,0);
        wall2.transform.localScale += new Vector3(0, 0.05f, 0);
        wall3.transform.localScale += new Vector3(0, 0.05f, 0);
        wall4.transform.localScale += new Vector3(0, 0.05f, 0);
       
        
        if (wall1.transform.localScale.y>1f)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void puttingoutfir()
    {
        if(hk.water>0)
        {
            playerwaterparticles.SetActive(true);
            hk.water--;
            wall1.transform.localScale -= new Vector3(0, 0.05f, 0);
            wall2.transform.localScale -= new Vector3(0, 0.05f, 0);
            wall3.transform.localScale -= new Vector3(0, 0.05f, 0);
            wall4.transform.localScale -= new Vector3(0, 0.05f, 0);
            if (wall1.transform.localScale.y <=0f)
            {
               isonfire= !isonfire;
                smoke.SetActive(false);
                wall1.transform.localScale = new Vector3(1, 0, 1);
                wall2.transform.localScale = new Vector3(1, 0, 1);
                wall3.transform.localScale = new Vector3(1, 0, 1);
                wall4.transform.localScale = new Vector3(1, 0, 1);
                canvas.SetActive(false);
               

            }

        }
    }
   
    private void FixedUpdate()
    {
        fireputout += Time.deltaTime;
        if (fireputout > 0.2f)
        {
            fireputout -= 0.2f;

            //waterassossiatedcode
            if (abv.isontop)
            {
                if (isonfire)
                {
                    puttingoutfir();
                }
            }
        }









        //fire assossiated code
        //Debug.Log(maybefire);
        maybefire = maybefire + 1 * Time.deltaTime;
        
        if (maybefire>1)
        {
            maybefire -= 1;
            if (!isonfire)
            {
               
                randomnum = Random.Range(1, probabl);
                randomnum2 = Random.Range(1, probabl);
                if (!abv.isontop)
                {
                    if (randomnum2 == randomnum)
                    {
                        isonfire = true;
                        ignitebuilding();
                    }
                }
            }else
            {
                burningbuilding();
               
              
              

            }
        }
        canvas.transform.LookAt(cam.transform);



    }


}
