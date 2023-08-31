using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour
{
    public float timerem = 0;
    public TMP_Text timetxt;
    public GameObject win;
    public helikoter hk;
    public float minutes;
    // Start is called before the first frame update
  private void Update()
    {
        Debug.Log(minutes);
        if(timerem>=0)
        {
            timerem += Time.deltaTime;
            display(timerem);
        }
       if (minutes>1)
        {
            hk.maxbuildingsonfire = 4;
            hk.probablility = 90;
        }
        if (minutes > 2)
        {
            hk.maxbuildingsonfire = 5;
            hk.probablility = 80;

        }
        if (minutes > 3)
        {
            hk.maxbuildingsonfire = 6;
            hk.probablility = 70;
        }
        if (minutes > 4)
        {
            hk.maxbuildingsonfire = 7;
            hk.probablility = 60;
        }
        if (minutes > 5)
        {
            hk.maxbuildingsonfire = 8;
            hk.probablility = 50;
        }
        if (minutes > 6)
        {
            hk.maxbuildingsonfire = 9;
            hk.probablility = 45;
        }
        if (minutes > 7)
        {
            hk.maxbuildingsonfire = 10;
            hk.probablility = 44;
        }
        if (minutes > 8)
        {
            hk.maxbuildingsonfire = 11;
            hk.probablility = 43;
        }
        if (minutes > 9)
        {
            hk.probablility = 60;
            hk.maxbuildingsonfire = 100;
        }
      
    }
    void display(float timedispl)
    {
        timedispl += 1;
         minutes = Mathf.FloorToInt(timedispl / 60);
        float seconds = Mathf.FloorToInt(timedispl % 60);
        timetxt.text = string.Format("{0:00} : {1:00}",minutes,seconds);

        if (minutes>=10)
        {
            win.SetActive(true);
        }
    }
}
