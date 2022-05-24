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
    [SerializeField] private float maxDetectTime;
    [SerializeField] private bool patrolWaiting = false;
    private EnemyFOV eF;
    private float waitTimer;
    private float detectTimer;
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
        ChaseAgent();
        PlayerAnimations();
    }

    void Patrolling()
    {
        if (!chaseAgent)
        {
            if (isTraveling && enemy.remainingDistance <= 1.0f)
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
    }

    void ChaseAgent()
    {
        if (chaseAgent)
        {
            detectTimer += Time.deltaTime;
                
            if (detectTimer >= maxDetectTime)
            {
                SetAgentDestination();
            }
            else if (!chaseAgent)
            {
                isTraveling = false;
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
            detectTimer = 0f;
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
        else
        {
            SetDestination();
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
        else
        {
            chaseAgent=false;
        }
    }
}
