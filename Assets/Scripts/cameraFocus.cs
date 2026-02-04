using UnityEngine;

public class cameraFocus : MonoBehaviour
{
    public Dialog_manager manager;
    public GameObject gameOb;
    int stop;
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
        if (other.tag == "Player" && stop == 0)
        {
            stop++;
            manager.cinemachineFreeLook.LookAt = gameOb.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            manager.cinemachineFreeLook.LookAt = manager.Player.transform;
        }
    }
}
