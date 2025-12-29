using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class P_QuestGiver : MonoBehaviour
{
    //public TMP_Text greetText;

    public NewDialogueData dialogueData;
    private int dialogueIndex;
    public bool isDialogueActive;

    //Temp Interaction Check
    public bool canInteract = false;

    //UI References (Would go into UI Controller)
    public GameObject dialoguePanel;
    public TMP_Text nameText;
    public TMP_Text dialogueText;


    void Start()
    {
        
    }

    private void Awake()
    {
        isDialogueActive = false;
    }

    void Update()
    {
        if(!isDialogueActive && canInteract && Input.GetKeyDown(KeyCode.E))
        {
            StartDialogue();
        }

        if(isDialogueActive && Input.GetKeyDown(KeyCode.E))
        {
            NextLine();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canInteract = true;
        
        //greetText.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        canInteract = false;
    }

    public void StartDialogue()
    {
        isDialogueActive = true;
        dialogueIndex = 0;
        dialoguePanel.SetActive(true);
        nameText.text = dialogueData.charName;
    }

    public void NextLine()
    {
        if (dialogueIndex >= dialogueData.dialogueLines.Length)
        {
            EndDialogue();
            return;
        }
        dialogueText.text = dialogueData.dialogueLines[dialogueIndex];
        dialogueIndex++;
    }

    public void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);
    }

}
