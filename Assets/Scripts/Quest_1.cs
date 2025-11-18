using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_1 : MonoBehaviour
{
    public bool goodJob;
    public bool goodJob2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && goodJob2 == false)
        {
          goodJob = true;  
        }
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        goodJob=false;
        if (other.tag == "Quest")
        {
            goodJob2 = true;
            goodJob = false;
        }
    }
    public void secondQuest()
    {

    }
}
    