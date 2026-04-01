
using UnityEngine;

public class NPC_Pathing : MonoBehaviour
{
    public Transform[] checkPoints;
    public int targetPoint;
    public float walkSpeed = 1f;
    public float rotationSpeed = 5f;
    //private Transform lookTarget;  -- From original NPC pathing.

    void Start()
    {
        // -- From original NPC pathing, unused in updated version. -- //

        //if (lookTarget = null)
        //{
        //    lookTarget = checkPoints[targetPoint].transform;
        //}
    }

    
    void Update()
    {
        // -- ORIGINAL NPC_PATHING -- //

        //if (Vector3.Distance(transform.position, checkPoints[targetPoint].position) <= 0.02f)
        //{
        //    IncreaseTargetInt();
        //}
        //transform.position = Vector3.MoveTowards(transform.position, checkPoints[targetPoint].position, walkSpeed * Time.deltaTime);
        //transform.LookAt(checkPoints[targetPoint].transform);


        // -- UPDATE NPC_PATHING, SMOOTHER ROTATIONS -- //

        Vector3 targetDirection = checkPoints[targetPoint].position - transform.position;

        if (targetDirection.magnitude <= 0.02f)
        {
            IncreaseTargetInt();
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, checkPoints[targetPoint].position, walkSpeed * Time.deltaTime);

        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        
    }
    
    void IncreaseTargetInt()
    {
        targetPoint++;
        if (targetPoint >= checkPoints.Length)
        {
            targetPoint = 0;
        }
    }
}
