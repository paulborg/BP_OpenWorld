using UnityEngine;

public class NPC_Static : MonoBehaviour
{

    public NPC_IdleType idleType;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        animator.SetInteger("IdleType", (int)idleType);
    }

}
