using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public float playerReach = 4f;
    Interactable currentInteractable;
  
    void Update()
    {
        CheckInteraction();

        if (Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    void CheckInteraction()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, playerReach);

        bool foundInteractable = false;

        foreach (var hitCollider in hitColliders)
        {
            if (!hitCollider.CompareTag("Interactable")) continue;

            Interactable interactable = hitCollider.GetComponent<Interactable>();

            if (interactable != null && interactable.enabled && !interactable.interactDisabled)
            {
                foundInteractable = true;

                if (currentInteractable != interactable)
                {
                    if (currentInteractable != null)
                    {
                        currentInteractable.HideInteractPrompt();
                    }

                    SetCurrentInteractable(interactable);
                }
                break;
            }
        }
        if (!foundInteractable)
        {
            DisableCurrentInteractable();
        }
    }

    #region CheckInteraction v1
    //void CheckInteraction()
    //{
    //    Collider[] hitColliders = Physics.OverlapSphere(transform.position, playerReach);
    //    foreach (var hitCollider in hitColliders)
    //    { 
    //        if (hitCollider.tag == "Interactable")
    //        {
    //            Interactable newInteractable = hitCollider.GetComponent<Interactable>();

    //            if (currentInteractable && newInteractable != currentInteractable)
    //            {
    //                currentInteractable.HideInteractPrompt();
    //            }

    //            if (newInteractable.enabled && !newInteractable.interactDisabled)
    //            {
    //                SetCurrentInteractable(newInteractable);

    //                Debug.Log("In range of " + currentInteractable);
    //            }
    //            else
    //            {
    //                DisableCurrentInteractable();
    //            }
    //        }
    //    }

    //}
    #endregion

    void SetCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.ShowInteractPrompt();
    }

    void DisableCurrentInteractable()
    {
        if (currentInteractable)
        {
            currentInteractable.HideInteractPrompt();
            currentInteractable = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, playerReach);
    }
}
