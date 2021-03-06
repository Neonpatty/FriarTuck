using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(LineRenderer))]
public class AgentController : MonoBehaviour
{
    //VARS
    public NavMeshAgent agent;
    public GameObject clickMarker;
    public Animator playerAnimator;
    public LayerMask block;
    public GameObject gameOverMenu;
    public GameObject levelComplete;

    [SerializeField] private Transform visualTransform;
    
    private RaycastHit hitPoint;
    private LineRenderer pathMarker;
    private bool isSelected = false;
    private AgentSelection aS;


    //Start is called at start up
    void Start()
    {
        aS = FindObjectOfType<AgentSelection>();
        LineRenderSetup(); 
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerAnimations();
        Deselect();
    }

    void PlayerMovement()
    {
        if (Input.GetMouseButtonDown(0) && isSelected && !IsMouseOverUI())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitPoint))
            {
                agent.SetDestination(hitPoint.point);
                ClickMarkerActive();
            }
        }
        
        if (Vector3.Distance(agent.destination, transform.position) <= agent.stoppingDistance)
        {
            ClickMarkerInactive();
        }
        
        if (agent.hasPath)
        {
            DrawPath();
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

    void ClickMarkerActive()
    {
        clickMarker.SetActive(true);
        clickMarker.transform.position = agent.destination;
    }

    void ClickMarkerInactive()
    {
        clickMarker.SetActive(false);
        clickMarker.transform.position = visualTransform.transform.position;
    }

    void LineRenderSetup()
    {
        pathMarker = GetComponent<LineRenderer>();
        pathMarker.startWidth = 0.15f;
        pathMarker.endWidth = 0.15f;
        pathMarker.positionCount = 0;
    }

    void DrawPath()
    {
        pathMarker.positionCount = agent.path.corners.Length;
        pathMarker.SetPosition(0, transform.position);

        if(agent.path.corners.Length < 2)
        {
            return;
        }

        for(int i = 1; i < agent.path.corners.Length; i++)
        {
            Vector3 pointPosition = new Vector3(agent.path.corners[i].x, agent.path.corners[i].y, agent.path.corners[i].z);
            pathMarker.SetPosition(i, pointPosition);
        }

    }

    private void OnMouseDown()
    {
        if(aS.selectedAgent != gameObject && aS.selectedAgent != null)
        {
            aS.DeselectAgent();
        }
        isSelected = true;
        gameObject.GetComponent<Outline>().enabled = true;
        aS.SelectedAgent(gameObject);
    }

    public void Deselect()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if(aS.selectedAgent != null)
            {
                aS.DeselectAgent();
            }
            else
            {
                Debug.Log("No Agent Selected.");
            }
        }
    }

    public void DeselectAgent()
    {
        isSelected = false;
        gameObject.GetComponent<Outline>().enabled = false;
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemies")
        {
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        if (other.gameObject.tag == "LevelEnd")
        {
            levelComplete.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
