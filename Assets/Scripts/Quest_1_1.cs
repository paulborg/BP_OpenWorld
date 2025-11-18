using UnityEngine;

public class Quest_1_1 : MonoBehaviour
{
    public bool ePress;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            ePress = true;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        ePress = false; 
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Quest_1 quest) && ePress == true)
        {
            quest.goodJob = true;        
        }   
    }
}
