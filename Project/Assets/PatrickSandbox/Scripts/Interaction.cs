using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interaction : MonoBehaviour
{
    //VARS
    public GameObject dropdownMenu;
    public GameObject buttonPrefab;

    [SerializeField] private GameObject interObj;
    [SerializeField] private Transform buttonParent;
    [SerializeField] private CameraCycle cC;
    [SerializeField] private CamsMenu cM;

    private GameObject button;
    private bool interacting = false;
    private RaycastHit hitPoint;

    // Update is called once per frame
    void Update()
    {
        ClickToOpen();
    }

    void ClickToOpen()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hitPoint);
        GameObject gO = hitPoint.transform.gameObject;
        Outline outline = gO.GetComponent<Outline>();

        if (gO.tag == "Interact")
        {
            outline.enabled = true;

            if (Input.GetMouseButtonDown(1) && !interacting)
            {
                interacting = true;
                dropdownMenu.SetActive(true);
                button = Instantiate(buttonPrefab);
                button.transform.SetParent(buttonParent);               
                button.GetComponent<Button>().onClick.AddListener(HackSuccess);
            }
        }
        else if (Input.GetMouseButtonDown(1) && interacting)
        {
            interacting = false;
            dropdownMenu.SetActive(false);
            Destroy(button);
        }
        else
        {
            Debug.Log("No Interactable");
        }

    }

    public void HackSuccess()
    {
        if (interObj.tag == "Door")
        {
            Animator ani = interObj.GetComponent<Animator>();
            if (ani.GetBool("Hacked") == false)
                ani.SetBool("Hacked", true);
            else
                ani.SetBool("Hacked", false);
        }

        if (interObj.tag == "MainCamera")
        {
            interObj.AddComponent<Camera>();
            Camera cam = (Camera)interObj.GetComponent<Camera>();
            cC.cams.Add(cam);
            cC.ResetCameras();
            cM.UpdateCams();
        }

        interacting = false;
        dropdownMenu.SetActive(false);
        Destroy(button);
    }
}
