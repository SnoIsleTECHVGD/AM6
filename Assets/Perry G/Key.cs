using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool hasKey = false;
    public GameObject key;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hasKey = true;
        Destroy(key);

    }
}
