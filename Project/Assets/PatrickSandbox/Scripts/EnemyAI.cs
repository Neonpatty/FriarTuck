using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //VARS
    public Transform[] targets;
    public NavMeshAgent enemey;
    public string waypointTag;

    private int currentTarget;
    private bool isTraveling = false;

    // Start is called before the first frame update
    void Start()
    {
        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        Patrolling();
    }

    void Patrolling()
    {
        if(isTraveling && enemey.remainingDistance <= 1.0f)
        {
            isTraveling = false;
            NewDestination();
            SetDestination();
        }
    }

    void SetDestination()
    {
        if(targets != null)
        {
            Vector3 destination = targets[currentTarget].transform.position;
            enemey.SetDestination(destination);
            isTraveling = true;
        }
    }
    
    void NewDestination()
    {
        currentTarget = (currentTarget + 1) % targets.Length;
    }
}
