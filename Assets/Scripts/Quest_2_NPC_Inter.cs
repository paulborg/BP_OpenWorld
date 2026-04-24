using TMPro;
using UnityEngine;

public class Quest_2_NPC_Inter : MonoBehaviour
{
    public Quest_2 quest;
    public Dialog_manager diManager;
   
    bool canInteract;
    bool isDialogActive;

    public bool Epress;
    private TMP_Text npcDia;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( isDialogActive && !canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Nextline();
        }
        // this is the script im thinking of using for the end Npc dialog or something 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (quest.dialogindex > 3)
        {
            if (other.TryGetComponent(out Dialog_manager manager) && other.TryGetComponent(out Ui_manager ui_manager))
            {
                Epress = false;
                manager.nDialog = npcDia;
                ui_manager.nUiOn();
                ui_manager.nDialog = npcDia;
                    if (!canInteract)
                    {
                        npcDia.text = quest.Talk.initiationLines[0];
                        canInteract = true;
                    }
                    else if (canInteract)
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
        if (canInteract && Epress && !isDialogActive)//&& interact == true ???)
        {
            startDialog();
            isDialogActive = true;
        }
    }
    public void startDialog()
    {
        diManager.typing(quest.Talk.QuestLines[quest.dialogindex]); 
        diManager.stopMoving();    
        quest.dialogindex++;
    }
    public void Nextline()
    {
        if (quest.dialogindex >= quest.Talk.QuestLines.Length)
        {

            EndDialog();
            return;
        }        
            diManager.typing(quest.Talk.QuestLines[quest.dialogindex]);
            quest.dialogindex++;        
    }
    public void EndDialog()
    {
        canInteract = false;
        diManager.startMoving();
    }


}
