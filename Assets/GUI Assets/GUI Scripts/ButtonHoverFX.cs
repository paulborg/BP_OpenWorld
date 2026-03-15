using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverFX : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Circle Animation")]
    public Animator circleAnimator;
    //private bool isHovering = false;


    //++ Scale Effect (Pick and import tweening libraries for better/easier controls)
    //++ Color Effect
    //++ Sound Trigger

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Awake()
    {

    }

    void Start()
    {
        //isHovering = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        //isHovering = false;

        ResetHoverState();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        //isHovering = true;

        if (circleAnimator != null && !circleAnimator.GetCurrentAnimatorStateInfo(0).IsName("Draw Selection"))
        {
            circleAnimator.SetBool("isHovering", true);
            circleAnimator.Play("Draw Selection", 0, 0);
        }
        gameObject.LeanScale(new Vector3(2, 2), 0.2f).setEaseInOutBack();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //isHovering = false;
        circleAnimator.SetBool("isHovering", false);

        gameObject.LeanScale(new Vector3(1.5f, 1.5f), 0.2f).setEaseInOutBack();
    }

    public void ResetHoverState()
    {
        Debug.Log("ResetHover Called");
        //isHovering = false;
        circleAnimator.SetBool("isHovering", false);
        circleAnimator.Rebind();
        circleAnimator.Update(0f);
        gameObject.LeanScale(new Vector3(1.5f, 1.5f), 0f);
    }

}
