using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_element_control : MonoBehaviour
{

    public GameObject ima;
    public Key that;
    public void Start()
    {
        ima.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (that.hasKey)
        {
            ima.SetActive(true);
        }
    }
}
