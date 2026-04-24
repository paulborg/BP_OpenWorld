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
    bool questStart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Dialog_manager manager) && other.TryGetComponent(out Ui_manager ui_manager))
        {
            manager.nDialog = npcDia;
            ui_manager.nUiOn();
            ui_manager.nDialog = npcDia;
            if (questStart == false)
            {
                npcDia.text = Talk.initiationLines[0];
            }
            else if (questStart == true)
            {
                npcDia.text = Talk.whileQuestLines[0];
            }
            
        }
    }
}
