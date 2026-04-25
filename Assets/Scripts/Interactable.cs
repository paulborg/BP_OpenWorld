using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [Header("Interactable Info")]
    //public string label;
    public Canvas interactPrompt;
    public bool interactDisabled;

    [Header("Interaction Events")]
    public UnityEvent onInteract;



    void Start()
    {
        
    }


    public void Interact()
    {
        if (interactDisabled)
        {
            return;
        }

        Debug.Log("INTERACTED");

        onInteract.Invoke();
        
        HideInteractPrompt();
    }

    public void DisableInteract()
    {
        interactDisabled = true;
    }

    public void ShowInteractPrompt()
    {
        interactPrompt.enabled = true;
    }

    public void HideInteractPrompt()
    {
        interactPrompt.enabled = false;
    }

}
