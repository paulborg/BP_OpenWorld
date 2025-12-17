using UnityEngine;

public class Poledialog : MonoBehaviour
{
    public Dialog_manager manager;
    private bool Epress;
    public string[] dialog;
    public bool startDia = false;
    public Quest_1 Quest;
    private bool restartDia;
    public Ui_manager managerUi;
    public int Qcount;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Epress = true;
        }
        Debug.Log(Quest.Qcount);
        Debug.Log(startDia);
        if (Qcount == 3)
        {
            managerUi.active_quest("Give Mr his news papers");
        }
    }
    private void OnTriggerEnter(Collider other)
    {    
            Epress = false;
        if (other.tag == "Player" && startDia == false  )
        {  
            manager.Npc = gameObject;
            startDia = true;             
            manager.nDialog.rectTransform.position = gameObject.transform.position + new Vector3(0, 1.5f, 0);
            manager.typing("Hei dont touch me there, because you Did that you have to gather the towns news papers");
            managerUi.active_quest("Gather News paper for Mr.pole");
            manager.lookAT();           
        }
        
        if (other.tag == "Player" && Qcount == 3)
        {
            manager.Npc = gameObject;
            manager.typing("Oh you have gathered the News papers, thank you and for you efferts here");
            manager.lookAT();
            managerUi.questCompletion();
            Debug.Log("this should not be here");
            Qcount++;
        }
        if (other.tag == "Player")
        {
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }    
    private void OnTriggerStay(Collider other)
    {
        if (restartDia == true && Epress == true && Qcount == 0)
        {
            manager.typing("Hei dont touch me there");
            restartDia = false;
            manager.lookAT();
        }
        if (Qcount < 4 && Qcount > 0 && Epress == true && restartDia == true)
        {
            manager.typing("Have you found my news papers");
            restartDia = false;
            manager.lookAT();
        }

        if (Qcount == 4 && Epress == true && restartDia == true)
        {
            manager.Npc = gameObject;
            manager.typing("Oh you have gathered the News papers, thank you and for you efferts here");
            manager.lookAT();
            restartDia = false;
            Debug.Log("this should not be here");        
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.tag == "Player")
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = true;
            manager.lookback();
            manager.StopAllCoroutines();
            manager.dialogManager = 0;
            restartDia = true;
            Epress = false;
        }
    }
    
}
