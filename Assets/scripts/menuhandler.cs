using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class menuhandler : MonoBehaviour
{
    public GameObject startpanel,howtioau,deathscreen,winscreen,pausemenu;
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
             Pausemenu();

        }
    }
    private void Start()
    {
        Time.timeScale = 0;
    }

   public void onstart()
    {
        Time.timeScale = 1;
        startpanel.SetActive(false);

    }
    public void activatemenu()
    {
        howtioau.SetActive(true);

    }

    public void Pausemenu()
    {
        Time.timeScale = 0;
        pausemenu.SetActive(true);
    }

    public void exit()
    {
        Application.Quit();
        
    }
    public void resttart()
    {
        Application.LoadLevel(0);
        
    }

}
