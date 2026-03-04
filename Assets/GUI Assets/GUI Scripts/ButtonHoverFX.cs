using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverFX : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Circle Animation")]
    public Animator circleAnimator;

    private bool isHovering;


    //++ Scale Effect (Pick and import tweening libraries for better/easier controls)
    //++ Color Effect
    //++ Sound Trigger

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;

        if (circleAnimator != null && !circleAnimator.GetCurrentAnimatorStateInfo(0).IsName("Draw Selection"))
        {
            circleAnimator.SetBool("isHovering", true);
            circleAnimator.Play("Draw Selection", 0, 0);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        circleAnimator.SetBool("isHovering", false);
    }
}
