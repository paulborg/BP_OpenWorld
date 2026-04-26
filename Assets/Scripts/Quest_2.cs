using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Quest_2 : MonoBehaviour
{
    [SerializeField] Ui_manager uiManager;
    [SerializeField] Dialog_manager diManager;
    Quest_2 quest;
   
    public DialogueSO Talk;
    public TMP_Text npcDia;
    public TMP_Text pDia;
   
    bool canInteract;   
    public bool Epress;
    bool isDialogActive;
    public bool isQuestActive;
    
    public int dialogindex;
    public int eventseq;
    
    // interactable 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eventseq = 0;
        isQuestActive = false;
        isDialogActive = false;
        Epress = false;
        canInteract = false;
        
        dialogindex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(dialogindex);
        if(Input.GetKeyDown(KeyCode.E))
        {
            Epress = true; 
            
        }
        if (Input.GetKeyDown(KeyCode.G) && eventseq == 2) // is quest active needs to be there so that you cant do the promt before you strat the quest and after you start the quest &&  is dialog active is there to stop it from functoning in the middle of a dialogue
        {
           
            wcainteraction();

        }
        

        if (eventseq == 1 && Input.GetKeyDown(KeyCode.E) && isDialogActive)
        {
            Nextline();
        }

        
       
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.TryGetComponent(out Dialog_manager manager) && other.TryGetComponent(out Ui_manager ui_manager))
        {
            Epress = false ;
            
            
            manager.nDialog = npcDia;
            ui_manager.nUiOn();
            ui_manager.nDialog = npcDia;
            if (!canInteract)
            {
                npcDia.text = Talk.initiationLines[0];
                canInteract = true;
                isQuestActive=true;
            }
            else if (canInteract && dialogindex == 3)
            {
                npcDia.text = Talk.whileQuestLines[0];
            }
           
            if (eventseq == 3)
            {
                npcDia.text =Talk.endQuestLines[0];
                isQuestActive = false;
                endOfQuest();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        //interact()
        //lock player movement 
        // show dialog on screenspace
        if (eventseq == 0 && Epress && !isDialogActive )//&& interact == true ???)
        {
            startDialog();
            isDialogActive = true;
            eventseq++;
        }
    }
    public void startDialog()
    {
        diManager.typing(Talk.QuestLines[dialogindex]);
        diManager.stopMoving();
        Debug.Log("youdidit");
        //dialogindex++;  
        
    }
    public void Nextline()
    {
        if (dialogindex == 2)
        {

            EndDialog();
            return;
        }
        else if (dialogindex < 2)
        {
            dialogindex++;
            diManager.typing(Talk.QuestLines[dialogindex]);
            
        }
    }
    public void EndDialog()
    { 
        
        isDialogActive = false;
        diManager.startMoving();
        eventseq++;
    }
    public void wcainteraction()
    {
        uiManager.pDialog= pDia;
        diManager.pDialog = pDia;
        diManager.pTyping(Talk.pDialogueLines[0]);
        
        
        // while quest is active
            
    }
   
    public void endOfQuest()
    {
        eventseq++;
        eventseq++;
        isQuestActive = false;
    }

}
