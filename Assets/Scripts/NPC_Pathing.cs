
using UnityEngine;

public class NPC_Pathing : MonoBehaviour
{
    public Transform[] checkPoints;
    public int targetPoint;
    public float speed;
    private Transform lookTarget;

    void Start()
    {
        if (lookTarget = null)
        {
            lookTarget = checkPoints[targetPoint].transform;
        }
    }

    
    void Update()
    {
        if (Vector3.Distance(transform.position, checkPoints[targetPoint].position) <= 0.02f)
        {
            IncreaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, checkPoints[targetPoint].position, speed * Time.deltaTime);
        transform.LookAt(checkPoints[targetPoint].transform);
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
