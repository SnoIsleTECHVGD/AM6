using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Button : MonoBehaviour
{
  
    public GameObject player;
    public GameObject PauseScreen;
    public GameObject key;
  

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(player.GetComponent<PlayerMovement>().enabled == false)
            {
                player.GetComponent<Rigidbody2D>().gravityScale = 0;
                player.GetComponent<PlayerMovement>().enabled = true;
                PauseScreen.SetActive(false);
                Cursor.visible = true;
                key.SetActive(false);
            }
            else
            {
                player.GetComponent<PlayerMovement>().enabled = false;
                PauseScreen.SetActive(true);
                player.GetComponent<Rigidbody2D>().gravityScale = 5;
                Cursor.visible = false;
                key.SetActive(true);
            }
        }   
        
    }
}
