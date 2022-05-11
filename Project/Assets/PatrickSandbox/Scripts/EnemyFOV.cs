using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angel;

    public GameObject agentRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool agentSeen;


    // Start is called before the first frame update
    void Start()
    {
        agentRef = GameObject.FindGameObjectWithTag("Agent");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if(rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angel / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    agentSeen = false;
                else
                    agentSeen = true;
            }
            else
                agentSeen = false;
        }
        else if(agentSeen)
            agentSeen = false;
    }
}
