using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    //VARS
    public NavMeshAgent agent;
    public GameObject targetDes;
    // Update is called once per frame
    void Update()
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
}
