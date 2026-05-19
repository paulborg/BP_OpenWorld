using UnityEngine;

public class Pickups : MonoBehaviour
{
     public Poledialog poledialog;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Player" && poledialog.Ppickup== true)
       {          
                gameObject.SetActive(false);
                poledialog.Qcount++;
               
            
       }
    }
}
