using UnityEngine;

public class HEi_Quest : MonoBehaviour
{
    [SerializeField] Dialog_manager manager;
    [SerializeField] Ui_manager ui_manager;
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
            ui_manager.nUiOn();
            manager.typing("Hei!");
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
