using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Button : MonoBehaviour
{
  
    public GameObject player;
    public GameObject PauseScreen;
  

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(player.GetComponent<PlayerMovement>().enabled == false)
            {
                player.GetComponent<PlayerMovement>().enabled = true;
                PauseScreen.SetActive(false);
            }
            else
            {
                player.GetComponent<PlayerMovement>().enabled = false;
                PauseScreen.SetActive(true);
            }
        }   
        
    }
}
