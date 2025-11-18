using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_1 : MonoBehaviour
{
    public Text success;
    public Text task;
    public bool goodJob;
    public bool goodJob2;
    public int myNumber = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        task.text = "Walk with WASD";
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && task.text == "Walk with WASD")
        {
          questCompletion();
          task.text = "Reach the red box";
        }
        Debug.Log(myNumber);
    }
    IEnumerator Ui()
    {
        goodJob2 = true;       
        yield return new WaitForSeconds(1);
        if (myNumber <= 3 && myNumber != 0)
        {
            myNumber--;
            StartCoroutine(Ui());
        }
        if (myNumber == 0)
        {
            success.gameObject.SetActive(false);
            myNumber=3;
            StopAllCoroutines();
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        goodJob=false;
        if (other.tag == "Quest" && task.text == "Reach the red box")
        {
            task.text = "Reach the red pole";
            questCompletion();
            goodJob2=true;
        }
    }
    public void questCompletion()
    {
        goodJob=true;
        success.gameObject.SetActive(true);
        
        StartCoroutine(Ui());
        
    }
}
    