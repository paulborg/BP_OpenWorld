using TMPro;
using UnityEngine;

public class HEi_Quest : MonoBehaviour
{
    [SerializeField] Dialog_manager manager;
    [SerializeField] Ui_manager ui_manager;
    public TMP_Text npcDia;
    int speech;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GetComponent<Dialog_manager>();
        ui_manager = GetComponent<Ui_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent (out Dialog_manager manager ) && other.TryGetComponent(out Ui_manager ui_manager))
        {
            manager.nDialog = npcDia;
            ui_manager.nDialog = npcDia;
            speech = Random.Range(1, 4);
            ui_manager.nUiOn();
            switch (speech)
            { 
                    case 1:
                manager.typing("Hei!");
                break;
                    case 2:
                    manager.typing("You in a hurry");
                    break;
                    case 3:
                    manager.typing("Kids");
                    break;
                default:
                   break;
               
                    
            }
            
            Debug.Log(speech);
        }   
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Dialog_manager manager) && other.TryGetComponent(out Ui_manager ui_manager))
        {
            ui_manager.nUiOff();
        }
    }
}
