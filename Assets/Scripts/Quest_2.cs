using Unity.VisualScripting;
using UnityEngine;

public class Quest_2 : MonoBehaviour
{
    Ui_manager uiManager;
    Dialog_manager diManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // start quest 
        }
    }
}
