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
    private float Typespeed;
    public Camera Camera;
    public GameObject Npc;
    public GameObject Player;
    public ThirdPersonController Controller; 
    public CinemachineVirtualCamera VirtualCamera;
    public CinemachineConfiner Confiner;

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
        Quest = GetComponent<Quest_1>();
        #region

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
        if (Input.GetKey(KeyCode.Q))
        {
            Typespeed = 0.0001f;
        }

        nDialog.rectTransform.LookAt(Camera.main.transform);
        nDialog.rectTransform.Rotate(0, 180, 0);
        
       
    }
    #endregion 
    
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

    #region
    // testing some stuff
    //IEnumerator Typespeed()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    foreach (char letter in Quest.task.text)
    //    {
    //        switch (speech)
    //        {
    //            case Speech.Hei:
    //                break;
    //            case Speech.WOw:
    //                break;
    //            case Speech.Hmm:
    //                break;
    //            case Speech.YOu:
    //                break;
    //            case Speech.oooo:
    //                break;
    //        }
    //    }
    //}
    #endregion
    public void typing(string message)
    {
        //Controller = FindAnyObjectByType<ThirdPersonController>();
        //Controller.MoveSpeed = 0;
        if (dialogManager == 0)
        {
            VirtualCamera.Follow = Npc.transform;
            VirtualCamera.LookAt = Npc.transform;
            Confiner.enabled = true;
            StartCoroutine(TypeOut(message));
            dialogManager = 1;
        }
        nDialog.gameObject.SetActive(true);  
        
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
    public enum Speech
    {
        Slow,
        Medium,
        Fast
        

    }
    public void lookAT()
    {
        VirtualCamera.Follow = Npc.transform;
        VirtualCamera.LookAt = Npc.transform;
        Confiner.enabled = true;
    }
    public void lookback()
    {
        VirtualCamera.Follow = Player.transform;
        VirtualCamera.LookAt = null;    
        Confiner.enabled = false;

    }

    public void OnButtonClick(string message)
    {
      pDialog.gameObject.SetActive(true);
      nDialog = pDialog;
      StartCoroutine(TypeOut(message));
    }

}
    



