//using JetBrains.Annotations;
//using UnityEditor.Rendering;
using UnityEngine;

public class Poledialog : MonoBehaviour
{
    public Dialog_manager manager;
    public Quest_1 Quest;
    public Ui_manager managerUi;
    public DialogueSO DialogueSO;
    
    public int Qcount;
    int dialogueIndex;
    
    public bool Ppickup;
    public bool startDia;
    public bool dialogexpired;
    public bool restartDia;
    public bool Epress;    
    public bool isDialogActive;

    public string[] dialog;
    
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogexpired = false;
        Ppickup = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Qcount);
        if (isDialogActive && Input.GetKeyDown(KeyCode.E) && manager.dialogManager == 0)
        {
            nextLine();
        }
        #region 
        if (Input.GetKey(KeyCode.E))
        {
            Epress = true;
        }
        //Debug.Log(Quest.Qcount);
        //Debug.Log(startDia);
        switch (Qcount)
        {
            case 0:
                break;
            case 1:
                managerUi.active_quest(DialogueSO.activeQuestProgression[1]);
                //managerUi.active_quest(DialogueSO.whileQuestLines[2]);
                break;
            case 2:
                managerUi.active_quest(DialogueSO.activeQuestProgression[2]);
                //managerUi.active_quest(DialogueSO.whileQuestLines[3]);
                break;
            case 3:
                managerUi.active_quest(DialogueSO.activeQuestProgression[3]);
                break;
            case 4:
                managerUi.active_quest(DialogueSO.activeQuestProgression[4]);
                break;
            default:
                managerUi.active_quest("");
                break;
        }      
        #endregion
    }
    private void OnTriggerEnter(Collider other)
    {    
            Epress = false;
        if (other.tag == "Player" && startDia == false && !Ppickup)
        {  

            manager.Npc = gameObject;
            //startDia = true;           
            manager.typing(DialogueSO.initiationLines[0]);            
            manager.lookAT();
            dialogexpired = false;
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<SphereCollider>().enabled = false;
            Debug.Log("Boop");

            //manager.nDialog.rectTransform.position = gameObject.transform.position + new Vector3(0, 1.5f, 0);
        }
        
        if (other.tag == "Player" && Qcount == 3)
        {
            manager.Npc = gameObject;
            manager.typing(DialogueSO.endQuestLines[0]);
            manager.lookAT();
            //managerUi.questCompletion();
            
            Qcount++;
        }
        //if (other.tag == "Player")
        //{
        //    GetComponent<BoxCollider>().enabled = true;
        //    GetComponent<SphereCollider>().enabled = false;
        //    Debug.Log("Boop");
        //}
    }    
    private void OnTriggerStay(Collider other)
    {
        if (isDialogActive && !dialogexpired && manager.dialogManager == 0 && Epress && !restartDia)
        {
            dialogexpired = true;
            restartDia = true;
            //isDialogActive = true;
            startDialog();
            
        }
        #region 
        if (dialogueIndex >= DialogueSO.QuestLines.Length)
        {
            managerUi.active_quest(DialogueSO.activeQuestProgression[0]);                       
        }       
        if (restartDia && Epress && Qcount == 0 && !isDialogActive)
        {
            manager.typing(DialogueSO.whileQuestLines[0]);
            restartDia = false;
            //manager.lookAT();
        }
        if (Qcount < 4 && Qcount == 0 && Epress && restartDia &&!isDialogActive)
        {
            manager.typing(DialogueSO.whileQuestLines[0]);
            restartDia = false;
            //manager.lookAT();
        }
        if (Qcount < 4 && Qcount == 1 && Epress && restartDia && !isDialogActive)
        {
            manager.typing(DialogueSO.whileQuestLines[1]);
            restartDia = false;
            //manager.lookAT();
        }
        if (Qcount < 4 && Qcount >= 2 && Epress && restartDia && !isDialogActive)
        {
            manager.typing(DialogueSO.whileQuestLines[2]);
            restartDia = false;
            //manager.lookAT();
        }
        if (Qcount == 4 && Epress && restartDia && !isDialogActive)
        {
            manager.Npc = gameObject;
            manager.typing(DialogueSO.endQuestLines[0]);
            manager.lookAT();
            restartDia = false;                  
        }
        #endregion
    }
    private void OnTriggerExit(Collider other)
    {        
        if (other.tag == "Player")
        {
            
            
                manager.lookback();
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<SphereCollider>().enabled = true;

                manager.StopAllCoroutines();
                manager.dialogManager = 0;
                restartDia = true;
                Epress = false;
            

        }
    }
    public void startDialog()
    {
        dialogueIndex= 0;
        //manager.nDialog.rectTransform.position = gameObject.transform.position + new Vector3(0, 1.5f, 0);
        Debug.Log("dialog started");
        manager.typing(DialogueSO.QuestLines[dialogueIndex]);
        dialogueIndex++;
        manager.stopMoving();
    }
    public void nextLine()
    {
        if (dialogueIndex >= DialogueSO.QuestLines.Length)
        {
            isDialogActive = true;
           endDialog();
            return;
        }        
        manager.typing(DialogueSO.QuestLines[dialogueIndex]);
        dialogueIndex++;
    }
    public void endDialog()
    {
        Ppickup = true;
        managerUi.nUiOff();
        isDialogActive = false;
        manager.startMoving();
        
    }
}
