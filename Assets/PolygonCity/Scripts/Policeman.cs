using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Policeman : MonoBehaviour
{
    private NavMeshAgent agent;
    private int index = 0;
    [SerializeField] private List<Transform> points;

    private Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 targetPosition = points[index].position;
        float targetSpeed = 0f;
        bool isWalkingState = false;
        bool isRunningState = false;

        if (index == 0 || index == 2)
        {
            targetSpeed = 2.5f;
            isWalkingState = true;
        }
        else if (index == 1 || index == 3)
        {
            targetSpeed = 3.5f;
            isRunningState = true;
        }

        agent.speed = targetSpeed;
        animator.SetBool("isWalking", isWalkingState);
        animator.SetBool("isRunning", isRunningState);

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            PointUpdate();
            targetPosition = points[index].position;
        }

        agent.SetDestination(targetPosition);
    }

    private void PointUpdate()
    {
        index++;
        if (index == points.Count)
        {
            index = 0;
        }
    }
   
}
