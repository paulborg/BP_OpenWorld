using UnityEngine;
using UnityEngine.AI;

public class NPC_AI_Agent : MonoBehaviour
{
    private NavMeshAgent npcAgent;
    private Animator npcAnimator;
    private float timer;

    public float wanderRadius = 10f;
    public float waitTime = 2f;

    void Start()
    {
        npcAgent = GetComponent<NavMeshAgent>();
        npcAnimator = GetComponent<Animator>();
        SetNewDestination();
    }

    
    void Update()
    {
        timer += Time.deltaTime;

        npcAnimator.SetFloat("Speed", npcAgent.velocity.magnitude);

        if (!npcAgent.pathPending && npcAgent.remainingDistance <= npcAgent.stoppingDistance)
        {
            if (timer >= waitTime)
            {
                SetNewDestination();
                timer = 0f;
            }
        }
    }

    void SetNewDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, NavMesh.AllAreas))
        {
            npcAgent.SetDestination(hit.position);
        }

    }


}
