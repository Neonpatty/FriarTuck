using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    //VARS
    public NavMeshAgent agent;
    public GameObject targetDes;
    public Animator playerAnimator;

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerAnimations();
    }

    void PlayerMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;

            if (Physics.Raycast(ray, out hitPoint))
            {
                targetDes.transform.position = hitPoint.point;
                agent.SetDestination(hitPoint.point);
            }
        }
    }

    void PlayerAnimations()
    {
        if(agent.velocity != Vector3.zero)
        {
            playerAnimator.SetBool("isWalking", true);
        }
        else if(agent.velocity == Vector3.zero)
        {
            playerAnimator.SetBool("isWalking", false);
        }
    }
}
