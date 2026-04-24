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
   
    bool canInteract;   
    bool Epress;
    bool isDialogActive;
    
    public int dialogindex;
    
    // interactable 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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


       if (canInteract && Input.GetKeyDown(KeyCode.E) && isDialogActive)
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
            }
            else if (canInteract)
            {
                npcDia.text = Talk.whileQuestLines[0];
            }
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        //interact()
        //lock player movement 
        // show dialog on screenspace
        if (canInteract && Epress && !isDialogActive )//&& interact == true ???)
        {
            startDialog();
            isDialogActive = true;
        }
    }
    public void startDialog()
    {
        diManager.typing(Talk.QuestLines[dialogindex]);
        diManager.stopMoving();
        Debug.Log("youdidit");
        dialogindex++;       
    }
    public void Nextline()
    {
        if (dialogindex == 3)
        {

            EndDialog();
            return;
        }
        else if (dialogindex < 3)
        {
            diManager.typing(Talk.QuestLines[dialogindex]);
            dialogindex++;
        }
    }
    public void EndDialog()
    { 
        canInteract = false;
        diManager.startMoving();
    }
}
