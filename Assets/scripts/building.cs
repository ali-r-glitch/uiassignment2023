using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isonfire;

    public float maxhealth,current,maybefire = 0;
    public int randomnum,randomnum2,probabl=20;
    public GameObject canvas,player,wall1, wall2, wall3, wall4;

    // Update is called once per frame\

    private void Start()
    {
        canvas = (transform.FindChild("Canvas")).gameObject;
        player = GameObject.Find("player");
    }

    void ignitebuilding()
    {
        // Find the child with the specified tag

        
        canvas.SetActive(true);
        current = maxhealth;
        burningbuilding();

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
    private void FixedUpdate()
    {
        //Debug.Log(maybefire);
        maybefire = maybefire + 1 * Time.deltaTime;
        
        if (maybefire>1)
        {
            maybefire -= 1;
            if (!isonfire)
            {
               
                randomnum = Random.Range(1, probabl);
                randomnum2 = Random.Range(1, probabl);

                if (randomnum2 == randomnum)
                {
                    isonfire = true;
                    ignitebuilding();
                }
            }else
            {
                burningbuilding();
              

            }
        }
        canvas.transform.LookAt(player.transform);



    }


}
