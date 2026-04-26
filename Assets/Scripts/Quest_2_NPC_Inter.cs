using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Quest_2_NPC_Inter : MonoBehaviour
{
    public Quest_2 quest;
    public Dialog_manager diManager;
    public Ui_manager uiManager;
    [SerializeField] Image npcImage;
    
   
    
    bool isDialogActive;

    int eventNumber;

    [SerializeField] private TMP_Text npcDia;
    private bool isQpressed;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eventNumber = 0;    
        
        isDialogActive = false;
        isQpressed = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(quest.dialogindex);
        if ( isDialogActive && eventNumber == 2 && Input.GetKeyDown(KeyCode.E) && diManager.dialogManager == 0)
        {
            Nextline();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            isQpressed = true;  
        }
        Debug.Log(eventNumber + "event");

        // this is the script im thinking of using for the end Npc dialog or something 
    }
    private void OnTriggerEnter(Collider other)
    {   
        quest.Epress = false;
        isQpressed = false;
        if (quest.dialogindex > 1 && eventNumber == 0)
        {
            if (other.TryGetComponent(out Dialog_manager manager) && other.TryGetComponent(out Ui_manager ui_manager))
            {                
                Debug.Log("youre here");
                ui_manager.nDialog = npcDia;
                manager.nDialog = npcDia;
                ui_manager.nUiOn();                
                ui_manager.image = npcImage;
                    if (eventNumber == 0)
                    {                        
                        eventNumber++;
                    }
                    else if (eventNumber >= 3)
                    {
                        npcDia.text = quest.Talk.whileQuestLines[0];
                    }
            }  
        }

       
    }
    private void OnTriggerStay(Collider other)
    {

        //interact()
        //lock player movement 
        // show dialog on screenspace
        if (isQpressed && quest.isQuestActive && eventNumber == 1)
        { 
            uiManager.imageOn();
            npcDia.text = quest.Talk.initiationLines[1];
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<SphereCollider>().enabled = true;
        }
        if (eventNumber == 1 && quest.Epress && !isDialogActive)//&& interact == true ???)
        { 
            isDialogActive = true;
            eventNumber++;
            startDialog();
            

        }
        

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Dialog_manager manager) && other.TryGetComponent(out Ui_manager ui_manager))
        {
           ui_manager.nUiOff();
        }
    }
    public void startDialog()
    {
        quest.dialogindex++;
        diManager.typing(quest.Talk.QuestLines[quest.dialogindex]); 
        diManager.stopMoving();
        uiManager.imageOff();
    }
    public void Nextline()
    {
        if (quest.dialogindex >= quest.Talk.QuestLines.Length)
        {

            EndDialog();
            return;
        }        
            quest.dialogindex++;
            diManager.typing(quest.Talk.QuestLines[quest.dialogindex]);
                    
    }
    public void EndDialog()
    {
        uiManager.pUiOff();
        eventNumber++;
        quest.eventseq++;        
        diManager.startMoving();
    }


}
