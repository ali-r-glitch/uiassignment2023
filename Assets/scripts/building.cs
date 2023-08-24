using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isonfire;
    public float maybefire = 0;
    public int randomnum,randomnum2,probabl=20;

    // Update is called once per frame
    private void FixedUpdate()
    {
        Debug.Log(maybefire);
        maybefire = maybefire + 1 * Time.deltaTime;
        if(maybefire>1)
        {
            maybefire -= 1;
            randomnum = Random.Range(1, probabl);
            randomnum2 = Random.Range(1, probabl);
            if (randomnum2 == randomnum)
            {
                isonfire = true;
            }
        }


    }
}
