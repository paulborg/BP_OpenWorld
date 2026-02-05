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
    public Button Button;
    public Canvas playerHUD;
    public Image journalBG;
    private bool journalOpen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        nDialog.rectTransform.LookAt(Camera.main.transform);
        nDialog.rectTransform.Rotate(0, 180, 0);
        //pDialog.rectTransform.LookAt(Camera.main.transform);
        //pDialog.rectTransform.Rotate(0, 180, 0);
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

    #region 
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
        }

        else
        {
            journalBG.gameObject.SetActive(false);
        }
        
    }

    //public void CloseJournal()
    //{
    //    journalBG.gameObject.SetActive(false);
    //}
}
