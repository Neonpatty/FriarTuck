using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //VARS
    public List<Transform> targets;
    public string wayPointTag;
    public Animator enemeyAni;

    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private float totalWaitTime;
    [SerializeField] private bool patrolWaiting = false;
    private EnemyFOV eF;
    private float waitTimer;
    private int currentTarget;
    private bool isTraveling = false;
    private bool waiting = false;
    private bool chaseAgent = false;



    // Start is called before the first frame update
    void Start()
    {
        eF = GetComponent<EnemyFOV>();
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
        Waiting();
        AgentSeen();
        PlayerAnimations();
    }

    void Patrolling()
    {
        if(isTraveling && enemy.remainingDistance <= 1.0f && (!chaseAgent))
        {
            isTraveling = false;

            if (patrolWaiting)
            {
                waiting = true;
                waitTimer = 0f;
            }
            else
            {
                NewDestination();
                SetDestination();
            }
        }
    }

    void Waiting()
    {
        if (waiting)
        {
            waitTimer += Time.deltaTime;
            
            if(waitTimer >= totalWaitTime)
            {
                waiting =false;
                NewDestination();
                SetDestination();

            }
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

    void SetAgentDestination()
    {
        if (chaseAgent)
        {
            Vector3 destination = eF.agentRef.transform.position;
            enemy.SetDestination(destination);
            isTraveling = true;
        }
    }
    
    void NewDestination()
    {
        currentTarget = (currentTarget + 1) % targets.Count;
    }

    void PlayerAnimations()
    {
        if (enemy.velocity != Vector3.zero)
        {
            enemeyAni.SetBool("isWalking", true);
        }
        else if (enemy.velocity == Vector3.zero)
        {
            enemeyAni.SetBool("isWalking", false);
        }
    }

    void AgentSeen()
    {
        if(eF.agentSeen)
        {
            chaseAgent = true;
        }
    }
}
