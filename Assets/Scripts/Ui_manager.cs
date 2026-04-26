using System.Collections;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ui_manager : MonoBehaviour
{
    public TMP_Text nDialog;
    public TMP_Text pDialog;
    public TMP_Text qDialog;
    public Text success;
    public TMP_Text activeQuest;
    public Image image;
    public Button Button;
    public Canvas playerHUD;
    public Image journalBG;

    public RectTransform questInfo;
    private bool journalOpen = false;
    private bool questInfoOpen = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        nDialog.rectTransform.LookAt(Camera.main.transform);
        nDialog.rectTransform.Rotate(0, 180, 0);
        pDialog.rectTransform.LookAt(Camera.main.transform);
        pDialog.rectTransform.Rotate(0, 180, 0);
        //pDialog.rectTransform.position = transform.position + new Vector3(0, 0.5f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Npc")
        {

            nDialog.rectTransform.position = other.transform.position + new Vector3(0, 2.5f, 0);
        }
    }

    #region
    public void pUiOn()
    {
        pDialog.gameObject.SetActive(true);
    }
    public void pUiOff()
    {
        pDialog.gameObject.SetActive(false);
    }
    #endregion
    #region NPC UI
    public void nUiOn()
    {
        nDialog.gameObject.SetActive(true);
    }
    public void nUiOff()
    {
        nDialog.gameObject.SetActive(false);
    }
    #endregion
    public void bottonOn()
    {
        Button.gameObject.SetActive(true);
    }
    public void bottonOff()
    {
        Button.gameObject.SetActive(false);
    }
    public void active_quest(string info)
    {
        activeQuest.text = info;    
    }
    public void imageOff()
    {
        image.gameObject.SetActive(false);  
    }
    public void imageOn()
    {
        image.gameObject.SetActive(true);
    }
    #region Ui IEnumerator (?? - For checking Objective Progress?)
    IEnumerator Ui()
    {
       
        yield return new WaitForSeconds(1);
        int myNumber = 0;
        if (myNumber <= 3 && myNumber != 0)
        {
            myNumber--;
            StartCoroutine(Ui());
        }
        if (myNumber == 0)
        {
            success.gameObject.SetActive(false);
            myNumber = 3;
            StopAllCoroutines();
        }

    }
    public void questCompletion()
    {
        success.gameObject.SetActive(true);
        StartCoroutine(Ui());
    }
    #endregion

    public void ToggleJournal()
    {
        journalOpen = !journalOpen;
        
        if (journalOpen) 
        {
            journalBG.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            journalBG.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    #region //Attempt at expandable active quest objective, but needs more work, to also adjust objective text placement + would be nice to animate it opening smoothly etc. etc.
    //public void ToggleQuestInfo()
    //{
    //    // Need a better way to check if quest is active, then change from Hidden to Partial here. Or Hidden -> Expanded on quest start, then Partial after delay.
    //    questInfoOpen = !questInfoOpen;
    //    if (questInfoOpen)
    //    {
    //        questInfo.transform.Translate(Vector3.down * 150f, Space.Self);
    //    }
    //    else
    //    {
    //        questInfo.transform.Translate(Vector3.up * 150f, Space.Self);
    //    }
    //}
    #endregion

    //public void CloseJournal()
    //{
    //    journalBG.gameObject.SetActive(false);
    //}
}
