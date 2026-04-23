using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using Unity.Splines.Examples;
using Unity.VisualScripting;
using StarterAssets;
using Cinemachine;


public class Dialog_manager : MonoBehaviour
{
    public TMP_Text nDialog;
    public TMP_Text pDialog;
    public Quest_1 Quest;
    public Speech speech;
    public int dialogManager;
    Ui_manager uiManager;
    private float Typespeed;
    public Camera Camera;
    public GameObject Npc;
    public GameObject Player;
    public ThirdPersonController Controller; 
    public CinemachineFreeLook cinemachineFreeLook;
    public CinemachineVirtualCamera VirtualCamera;
    public CinemachineConfiner Confiner;
    public StarterAssetsInputs StarterAssets;
    private int pDialogManager;
    public DialogueSO DialogueSO;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogManager = 0;
    }
    #region 
    // the dialogs
    // Update is called once per frame
    void Update()
    {
        #region Test

        //if (Quest.task.text == "Walk with WASD" && dialogManager == 0)
        //{

        //    typing("Hei champ why dont you try to move around any W A S D buttens should work");


        //}
        //if (Quest.task.text == "Reach the red box" && dialogManager == 1)
        //{
        //   StopAllCoroutines();
        //    typing("Wow good Job you managed to move you look a little lonely how about you talk to that red box over there");
        //}
        //if (Quest.task.text == "Reach the red pole" && dialogManager == 2)
        //{
        //    StopAllCoroutines();
        //    typing("Hmm he did say much thats new, maybe go to that red pole and try ot touch it he likes that");
        //}
        //if (Quest.task.text == "Press E to interact" && dialogManager == 3)
        //{
        //    StopAllCoroutines();
        //    typing("You need to touch him ;)");
        //}
        //if (Quest.task.text == "Completed" && dialogManager == 4)
        //{
        //    StopAllCoroutines();
        //    typing("oOOo wOw yOu dId iT");
        //}
        #endregion
        Quest = GetComponent<Quest_1>();
        
        if (Input.GetKey(KeyCode.Q))
        {
            Typespeed = 0.0001f;
        }

        //nDialog.rectTransform.LookAt(Camera.main.transform);
        //nDialog.rectTransform.Rotate(0, 180, 0);
        //pDialog.rectTransform.LookAt(Camera.main.transform);
        //pDialog.rectTransform.Rotate(0, 180, 0);
        //pDialog.rectTransform.position = Player.transform.position + new Vector3(0, 0.5f, 0);

        Debug.Log(dialogManager);
    }
    #endregion

    #region Npc Typing

    IEnumerator TypeOut(string message)
    {
        
        #region
        // testing some stuff
        //switch (dialogManager)
        //    {
        //        case 0:
        //            dialog.text = "Hei champ why dont you try to move around any W A S D buttens should work";
        //            break;
        //        case 1:
        //            dialog.text = "Wow good Job you managed to move you look a little lonely how about you talk to that red box over there";
        //            break;
        //        case 2:
        //            dialog.text = "Hmm he did say much thats new, maybe go to that red pole and try ot touch it he likes that";
        //            break;
        //        case 3:
        //            dialog.text = "You need to touch him ;)";
        //            break;
        //        case 4:
        //            dialog.text = "oOOo wOw yOu dId iT";
        //        break;
        //        default:
        //            dialog.text = "";
        //            break;
        //    }
        #endregion
        nDialog.text = "";
        foreach (char letter in message)
        {
            nDialog.text += letter;
            yield return new WaitForSeconds(Typespeed);
            
        }
        dialogManager = 0;
        //Controller = FindAnyObjectByType<ThirdPersonController>();
        //Controller.MoveSpeed = 2;
        
    }
    public void typing(string message)
    {
        //Controller = FindAnyObjectByType<ThirdPersonController>();
        //Controller.MoveSpeed = 0;
        if (dialogManager == 0)
        {
            
            StartCoroutine(TypeOut(message));
            dialogManager = 1;
        }
        //nDialog.gameObject.SetActive(true);  
        
        switch (speech)
        {            
            case Speech.Slow:
                Typespeed = 0.3f;
                break;
            case Speech.Medium:
                Typespeed = 0.1f;
                break;
            case Speech.Fast:
                Typespeed = 0.05f;
                break;
        }
        
    }
    #endregion

    #region Player Typing
    IEnumerator pTypeOut(string message)
    {

        #region
        // testing some stuff
        //switch (dialogManager)
        //    {
        //        case 0:
        //            dialog.text = "Hei champ why dont you try to move around any W A S D buttens should work";
        //            break;
        //        case 1:
        //            dialog.text = "Wow good Job you managed to move you look a little lonely how about you talk to that red box over there";
        //            break;
        //        case 2:
        //            dialog.text = "Hmm he did say much thats new, maybe go to that red pole and try ot touch it he likes that";
        //            break;
        //        case 3:
        //            dialog.text = "You need to touch him ;)";
        //            break;
        //        case 4:
        //            dialog.text = "oOOo wOw yOu dId iT";
        //        break;
        //        default:
        //            dialog.text = "";
        //            break;
        //    }
        #endregion 
        pDialog.text = "";
        foreach (char letter in message)
        {
            pDialog.text += letter;
            yield return new WaitForSeconds(Typespeed);

        }
        dialogManager = 0;
        //Controller = FindAnyObjectByType<ThirdPersonController>();
        //Controller.MoveSpeed = 2;

    }
    
    
    public void pTyping(string message)
    {
        //Controller = FindAnyObjectByType<ThirdPersonController>();
        //Controller.MoveSpeed = 0;
        if (pDialogManager == 0)
        {
           
            StartCoroutine(pTypeOut(message));
            pDialogManager = 1;
        }
        pDialog.gameObject.SetActive(true);

        switch (speech)
        {
            case Speech.Slow:
                Typespeed = 0.3f;
                break;
            case Speech.Medium:
                Typespeed = 0.1f;
                break;
            case Speech.Fast:
                Typespeed = 0.05f;
                break;
        }

    }
    #endregion 
    public enum Speech
    {
        Slow,
        Medium,
        Fast       
    }

    #region Looking
    public void lookAT()
    {
        //VirtualCamera.Follow = Npc.transform;
        //cinemachineFreeLook.Follow = null;
        cinemachineFreeLook.LookAt = Npc.transform;
        //VirtualCamera.LookAt = Npc.transform;
        Confiner.enabled = true;
        //StarterAssets.cursorLocked = false;
    }
    public void lookback()
    {
        //VirtualCamera.Follow = Player.transform;
        //VirtualCamera.LookAt = null;    
        cinemachineFreeLook.LookAt = Player.transform;
        Confiner.enabled = false;
        //StarterAssets.cursorLocked = true;
    }
    #endregion
    public void OnButtonClick(string message)
    {
      pDialog.gameObject.SetActive(true);
       pTyping("Sorry");   
    }
    public void stopMoving()
    {
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<Animator>().enabled = false;
        
        //GetComponent<CharacterController>().enabled = false;
        //GetComponent<ThirdPersonController>().enabled = false;
    }
    public void startMoving()
    {
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<Animator>().enabled = true;
        
        //GetComponent<CharacterController>().enabled = true;
        //GetComponent<ThirdPersonController>().enabled = true;
    }
}
    



