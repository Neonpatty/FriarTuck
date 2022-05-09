using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //VARS
    public List<Transform> targets;
    public string wayPointTag;

    [SerializeField] private NavMeshAgent enemy;
    private int currentTarget;
    private bool isTraveling = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag(wayPointTag))
        {
            targets.Add(go.transform);
        }
        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        Patrolling();
    }

    void Patrolling()
    {
        if(isTraveling && enemy.remainingDistance <= 1.0f)
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
            enemy.SetDestination(destination);
            isTraveling = true;
        }
    }
    
    void NewDestination()
    {
        currentTarget = (currentTarget + 1) % targets.Count;
    }
}
